using Backend.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Serilog
    builder.Host.UseSerilog((ctx, cfg) =>
        cfg.ReadFrom.Configuration(ctx.Configuration)
           .WriteTo.Console());

    // EF Core + PostgreSQL
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

    // FluentValidation
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();

    // Controllers
    builder.Services.AddControllers();

    // OpenAPI
    builder.Services.AddOpenApi();

    // Health checks
    builder.Services.AddHealthChecks();

    // CORS — allow React dev server
    builder.Services.AddCors(options =>
        options.AddDefaultPolicy(policy =>
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod()));

    var app = builder.Build();

    // OpenAPI at /openapi/v1.json, Swagger UI at /OpenAPI
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "Backend v1"));
    }

    app.UseSerilogRequestLogging();
    app.UseCors();
    app.UseAuthorization();
    app.MapControllers();
    app.MapHealthChecks("/health");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed to start");
}
finally
{
    Log.CloseAndFlush();
}
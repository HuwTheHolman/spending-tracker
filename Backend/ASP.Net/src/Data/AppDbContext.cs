using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // Add your DbSets here as you build features
    // e.g. public DbSet<Transaction> Transactions => Set<Transaction>();
}
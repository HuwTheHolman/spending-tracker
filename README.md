# Spending Tracker

A web application for importing your spending data and analysing where your money goes — helping you make smarter financial decisions.

## About

This project is a portfolio piece as well as a functional application. The tech stack and architecture decisions reflect both practical and portfolio considerations.

## Structure

This is a monorepo containing the frontend and backend. Each has its own README with setup and usage instructions.

```
spending-tracker/
├── frontend/    # React
├── backend/     # ASP.NET
└── README.md    # You are here
```

## Tech Stack

| Layer | Technology |
|---|---|
| Frontend | React |
| Backend | ASP.NET |
| Database | PostgreSQL |

## Architecture

The frontend and backend are fully decoupled. As long as the API contract (data in/out) remains consistent, the frontend behaves identically regardless of what powers the backend. This is intentional — it allows the backend to be swapped out for a different technology stack without touching the frontend, which is useful for portfolio purposes.

When the backend is replaced, it will be split into its own repository. For now, both live here for development simplicity.

## Generative AI Usage

With this project being for portfolio usage, there will be minimal usage of AI for code generation other than bug fixes and improvement suggestions. Some supporting documents will be generated using AI, such as most of this readme.

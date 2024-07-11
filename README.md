# Self Finance Management Application

## Description

This project consists of two main components: a .NET Core backend (Web API) and an ASP.NET Core Blazor UI (server-side) for managing self finance. The backend provides REST API endpoints for CRUD operations on income and expense types, as well as financial operations. It also includes endpoints for generating daily and date period reports. The Blazor UI offers an interactive interface for users to manage their finances and view reports.

## Features

### .NET Core Backend (Web API)

1. **CRUD Operations:**
    - Manage types of income and expenses.
    - Manage financial operations.

2. **Reports:**
    - **Daily Report:** Provides total income, total expenses, and a list of operations for a specified date.
    - **Date Period Report:** Provides total income, total expenses, and a list of operations for a specified date range.

### ASP.NET Core Blazor UI (Server-side)

1. **CRUD Operations:**
    - Manage types of income and expenses.
    - Manage financial operations.

2. **Reports:**
    - **Daily Report:** Input a date to view total income, total expenses, and a list of operations for that date.
    - **Date Period Report:** Input a start date and end date to view total income, total expenses, and a list of operations for that period.

## Prerequisites

- .NET 8 SDK
- Entity Framework Core
- ASP.NET Core
- ASP.NET Core Blazor

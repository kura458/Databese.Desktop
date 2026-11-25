# Databese.Desktop – Product Management System

A Windows desktop product-management application built with **C#**, **Windows Forms**, **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

The desktop client communicates with a REST API for user authentication and product-management operations.

## Features

### User authentication
- User registration
- User login
- Change password
- Password hashing through ASP.NET Core's `IPasswordHasher<User>`

### Product management
- Create products
- View products
- Update products
- Delete products
- Search products by name or ID
- Refresh the product list

### Data access
- SQL Server database
- Entity Framework Core
- Code-first migrations

## Technology stack

| Technology | Role |
|---|---|
| C# | Application language |
| Windows Forms | Desktop user interface |
| ASP.NET Core Web API | Backend API |
| Entity Framework Core | Object-relational mapping |
| SQL Server | Relational database |
| Visual Studio | Development environment |

## Solution structure

```text
Databese.Desktop/
├── Databese.Desktop.slnx
├── Databese.Desktop/
│   ├── Forms and form designer files
│   ├── Models/
│   ├── Services/
│   └── Program.cs
├── SE4.API/
│   ├── Controllers/
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Services/
│   ├── Program.cs
│   └── appsettings.json
└── SE4.data/
    ├── Context/
    ├── Entities/
    └── Migrations/
```

## API endpoints

### User API

| Method | Endpoint | Purpose |
|---|---|---|
| POST | `/api/Users/register` | Register a user |
| POST | `/api/Users/login` | Authenticate a user |
| POST | `/api/Users/change-password` | Change a password |

### Product API

| Method | Endpoint | Purpose |
|---|---|---|
| POST | `/api/Products` | Create a product |
| GET | `/api/Products` | Retrieve all products |
| GET | `/api/Products/{id}` | Retrieve a product |
| PUT | `/api/Products/{id}` | Update a product |
| DELETE | `/api/Products/{id}` | Delete a product |

## Requirements

- Windows
- Visual Studio
- .NET SDK compatible with the project files
- SQL Server
- Git

Check the project files for the exact target framework and package versions before installing dependencies.

## Run locally

### 1. Clone the correct repository

```bash
git clone https://github.com/kura458/Databese.Desktop.git
cd Databese.Desktop
```

### 2. Open the solution

Open `Databese.Desktop.slnx` in Visual Studio.

### 3. Configure SQL Server

Review the connection string configuration for `SE4.API`. Use your own local SQL Server instance and keep machine-specific credentials out of committed source files.

### 4. Apply database migrations

Use the Entity Framework Core migrations appropriate to the solution and configured database.

### 5. Start the API

Run the `SE4.API` project. The existing project documentation lists `https://localhost:7213/` as the configured API address; verify the actual launch settings in your local environment.

### 6. Start the desktop client

Run the `Databese.Desktop` project after the API and database are available.

## Security notes

- Do not commit real database passwords, API secrets, or production connection strings.
- Use a local development connection string or environment-specific configuration.
- Keep password handling on the server side.

## Author

**Kura Lemma**  
[GitHub: @kura458](https://github.com/kura458)

---

Educational project demonstrating a desktop client, REST API, and relational database working together.

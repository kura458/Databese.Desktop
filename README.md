# Databese.Desktop – Product Management System

A Windows desktop product-management application built with **C#**, **Windows Forms**, **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

The Windows Forms client communicates with the REST API for user authentication and product-management operations.

## Features

### User authentication
- User registration
- User login
- Change password
- Password hashing through ASP.NET Core's `IPasswordHasher<User>`

### Product management
- Create, view, update, and delete products
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
| .NET 10 | Target framework |
| Windows Forms | Desktop user interface |
| ASP.NET Core Web API | Backend API |
| Entity Framework Core 10 | Object-relational mapping |
| SQL Server | Relational database |
| Visual Studio | Development environment |

## Solution structure

```text
Databese.Desktop/
├── Databese.Desktop.slnx
├── Databese.Desktop/
│   ├── Forms and designer files
│   ├── Models/
│   ├── Services/ApiClient.cs
│   └── Program.cs
├── SE4.API/
│   ├── Controllers/
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Services/
│   ├── Properties/launchSettings.json
│   └── Program.cs
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
- .NET 10 SDK
- Visual Studio with the .NET desktop development workload
- SQL Server instance
- Git

## Run locally

### 1. Clone and open the solution

```cmd
git clone https://github.com/kura458/Databese.Desktop.git
cd Databese.Desktop
```

Open `Databese.Desktop.slnx` in Visual Studio, or use the .NET CLI from this directory.

### 2. Configure SQL Server

The API reads the `ConnectionStrings:DefaultConnection` setting from `SE4.API/appsettings.json`. The committed development value uses SQL Server on the local machine with Windows integrated authentication.

If your SQL Server instance or database credentials differ, configure the connection string for your local environment. You can override it without editing the committed file by setting the `ConnectionStrings__DefaultConnection` environment variable.

### 3. Restore dependencies

```cmd
dotnet restore Databese.Desktop.slnx
```

### 4. Apply database migrations

If the Entity Framework CLI is not installed, install a version matching the project's EF Core 10 packages:

```cmd
dotnet tool install --global dotnet-ef --version 10.0.15
```

Apply the migrations from the repository root:

```cmd
dotnet ef database update --project SE4.data/SE4.data.csproj --startup-project SE4.API/SE4.API.csproj
```

### 5. Start the API

Use the HTTPS launch profile. It configures the API at `https://localhost:7213`, which matches the desktop client's configured base address.

```cmd
dotnet run --project SE4.API/SE4.API.csproj --launch-profile https
```

Keep this terminal running.

### 6. Start the Windows Forms client

Open a second terminal in the repository root:

```cmd
dotnet run --project Databese.Desktop/Databese.Desktop.csproj
```

The desktop client expects the API to be available at `https://localhost:7213/`.

## Security notes

- The example connection string uses Windows integrated authentication; replace it with environment-specific configuration if your setup requires another authentication method.
- Do not commit real database passwords, API secrets, or production connection strings.
- Keep password handling and password hashing on the server side.
- The local HTTPS development certificate may need to be trusted on a new machine. Use `dotnet dev-certs https --trust` if required.

## Author

**Kura Lemma**  
[GitHub: @kura458](https://github.com/kura458)

---

Educational project demonstrating a Windows desktop client, REST API, and relational database working together.

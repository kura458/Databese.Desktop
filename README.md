# Databese.Desktop – Product Management System

A desktop-based Product Management System developed using **C#**, **Windows Forms (WinForms)**, **ASP.NET Core Web API**, **Entity Framework Core**, and **SQL Server**.

The application allows users to authenticate and manage products through a Windows desktop interface connected to a RESTful Web API.

## Features

### 1. User Authentication
- User registration
- User login
- Change password
- Secure password hashing using ASP.NET Core `IPasswordHasher<User>`

### 2. Product Management (CRUD)
- Add new products
- View all products
- Update existing products
- Delete products
- Search products by name or ID
- Refresh and display all products

### 3. Database Management
- SQL Server database integration
- Entity Framework Core
- Code-First database migrations

## Technologies Used

| Technology | Purpose |
|---|---|
| C# | Main programming language |
| Windows Forms | Desktop user interface |
| ASP.NET Core Web API | Backend services |
| Entity Framework Core | Object-relational mapping (ORM) |
| SQL Server | Database management |
| Visual Studio | Development environment |
| Git and GitHub | Version control and source code hosting |

## Project Structure

```text
Databese.Desktop/
│
├── Databese.Desktop.slnx
│
├── Databese.Desktop/
│   ├── Forms
│   ├── Models/
│   ├── Services/
│   └── Program.cs
│
├── SE4.API/
│   ├── Controllers/
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Services/
│   ├── Program.cs
│   └── appsettings.json
│
└── SE4.data/
    ├── Context/
    ├── Entities/
    └── Migrations/
```

## API Endpoints

### User API

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/Users/register` | Register a new user |
| POST | `/api/Users/login` | Authenticate a user |
| POST | `/api/Users/change-password` | Change user password |

### Product API

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/Products` | Create a product |
| GET | `/api/Products` | Get all products |
| GET | `/api/Products/{id}` | Get product by ID |
| PUT | `/api/Products/{id}` | Update a product |
| DELETE | `/api/Products/{id}` | Delete a product |

## Database Configuration

The application uses SQL Server.

Configure your database connection in:

`SE4.API/appsettings.json`

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=SE4DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"
  }
}
```

**Note:** Change the connection string according to your SQL Server installation.

## How to Run the Project

### Requirements

- Windows operating system
- Visual Studio
- .NET 10 SDK
- SQL Server
- Git

### Step 1: Clone the Repository

```bash
git clone https://github.com/kura458/Event-Driven-Programming-Practice.git
```

### Step 2: Open the Solution

Open `Databese.Desktop.slnx` using Visual Studio.

### Step 3: Configure the Database

Update the SQL Server connection string in `SE4.API/appsettings.json` if necessary.

Apply Entity Framework Core migrations to create or update the database.

### Step 4: Run the API

Set `SE4.API` as the startup project and run it.

The configured API address is:

```text
https://localhost:7213/
```

### Step 5: Run the Desktop Application

Run `Databese.Desktop` from Visual Studio.

Make sure the API is running before using the desktop application.

## Author

**Kura Lemma**

GitHub: https://github.com/kura458

## Project Purpose

This project demonstrates the development of a layered desktop application with a RESTful backend API and relational database. It applies practical concepts of object-oriented programming, API development, database integration, authentication, and CRUD operations.

## License

This project is available for educational and learning purposes.

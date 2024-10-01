# Dotnet 8 Identity Project

This project implements user authentication and authorization using ASP.NET Core Identity with .NET 8. It includes features such as user registration, login, role management, and more.

## Features

- User Registration & Login
- Role-based Authorization (Admin/User)
- Email confirmation
- Password reset
- Secure password hashing
- Token-based authentication (optional)

## Technologies Used

- .NET 8
- ASP.NET Core Identity
- Entity Framework Core
- SQLite (or specify your preferred database)
- Razor Pages or MVC (based on your project setup)
- MailKit (for email services)

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Code editor: Visual Studio, VSCodium, or VSCode
- Database: SQLite, SQL Server, or another supported database

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/Mu2011/Role-based-authorization.git
   ```

2. Install the required NuGet packages:

   ```bash
   dotnet restore
   ```

3. Configure the database connection in `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=Mu_Dotnet8Identity.db"
     }
   }
   ```

4. Apply Entity Framework Core migrations:

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. Access the application in your browser at:

   ```
   https://localhost:5001
   ```

## Additional Resources

- [ASP.NET Core Identity Documentation](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)
- [SQLite Documentation](https://sqlite.org/index.html)
- [Visual Studio Codium Documentation](https://vscodium.com/)
- [.NET Core Documentation](https://docs.microsoft.com/en-us/dotnet/core/)
- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [C# Documentation](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [Razor Pages Documentation](https://docs.microsoft.com/en-us/aspnet/core/mvc/razor-pages?view=aspnetcore-8.0)
- [ASP.NET Core MVC Documentation](https://docs.microsoft.com/en-us/aspnet/core/mvc/?view=aspnetcore-8.0)

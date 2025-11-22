CRM Management System – ASP.NET Core MVC

A fully functional Customer Relationship Management (CRM) System built with ASP.NET Core MVC, Entity Framework Core, and SQL Server, providing full control over Customers, Employees, Reports, and Dashboard analytics.

This project is built with clean architecture principles, strongly-typed models, MVC separation, and Bootstrap-based responsive UI.

📁 Project Structure Overview

The solution is organized into standard ASP.NET Core MVC layers as shown:

/Controllers
    AdminController.cs
    AuthController.cs
    CRMController.cs
    CRMReportController.cs
    EmployeeController.cs
    HomeController.cs
    mainController.cs
    SearchController.cs

/Data
    AppDbContext.cs

/Migrations
    (EF Core migration files)

/Models
    CRMReport.cs
    CRMUser.cs
    Customer.cs
    Employee.cs
    ErrorViewModel.cs

/Views
    /Admin
    /Auth
    /CRM
    /CRMReport
    /Employee
    /Home
    /main
        Dashboard.cshtml
    /NewFolder
    /Search
    /Shared


Each folder follows ASP.NET Core best practices and MVC conventions.

⭐ Key Features
📊 1. Interactive Dashboard

Implemented under Views/main/Dashboard.cshtml, the dashboard shows:

Total Customers

Total Employees

New Customers Today

New Employees Today

Recent Customers

Recent Employees

All data is dynamically fetched through EF Core in mainController.cs.

🔍 2. Advanced Search System

Handled by SearchController.cs, the search feature allows filtering by:

Name

Email

Phone

✔ Features:

AJAX-based instant results

No page reload

Bootstrap modal for detail previews

Optimized LINQ queries

👥 3. Customer Management

Managed by CRMController.cs and Customer.cs model:

Add Customer

Edit Customer

Delete Customer

List All Customers

Customer Summary & Activity View

Fully database-driven using Entity Framework Core.

💼 4. Employee Management

Implemented in EmployeeController.cs and the Employee.cs model:

Register Employee

Modify Employee Profile

Remove Employee

List All Employees

Role & Contact Information

📄 5. Reports Module

Through CRMReportController.cs and CRMReport.cs model:

Daily Activity Reports

Customer & Employee Summaries

Charts / Data Tables

Optional PDF/Excel export support

🛠️ Technology Stack
Technology	Purpose
ASP.NET Core MVC	Main framework
Entity Framework Core	ORM & Data Access
SQL Server	Relational Database
Bootstrap 5	UI Styling
LINQ	Data Filtering & Queries
AJAX / Fetch API	Live search & async operations

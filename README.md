
## Designation Management System
This is a web-based Designation Management System built using ASP.NET Core, Entity Framework Core, and SQL Server. It allows users to manage designations with features like filters, DataTables with server-side processing, and export to Excel/Print functionality.

# Technologies Used
Backend: ASP.NET Core (.NET 8)

ORM: Entity Framework Core

Database: Microsoft SQL Server

Frontend: HTML, CSS, JavaScript, jQuery

UI Libraries:

Bootstrap 5

DataTables.net

DataTables Extensions (Buttons, Print, Export)

## Getting Started
# Prerequisites
Visual Studio 2022 or later

NET 8 SDK installed

SQL Server (LocalDB or Full)

NuGet Packages:

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools

Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation (optional for hot reload)

# Setting Up the Project
1. Clone the Repository
   
git clone https://github.com/shubhamkarale1999/DesignationMaster.git

3. Check the Connection String
Ensure your appsettings.json has the correct SQL Server connection string:

"ConnectionStrings": {
  "DefaultConnection": "Data Source=.;Initial Catalog=DesignationMaster;Integrated Security=True;Trust Server Certificate=True"
}
Update YOUR_SERVER_NAME to match your local/remote SQL Server.

3. Update the Database
Use the Entity Framework Core CLI or Package Manager Console to apply migrations and create the database.

Using Package Manager Console (Visual Studio):

Add-Migration InitialCreate
Update-Database

Or using .NET CLI:

dotnet ef migrations add InitialCreate
dotnet ef database update
📊 Features
Filter designation list by:

College Name

Designation Name

Server-side pagination with DataTables

Export to Excel & Print buttons

Responsive & clean UI with Bootstrap

📂 Project Structure
markdown
Copy
Edit
Controllers/
  └── DesignationController.cs
Views/
  └── Designation/
      ├── Index.cshtml
      └── AddDesignation.cshtml
Models/
  └── Designation.cs
  └── College.cs
Data/
  └── ApplicationDbContext.cs

📌 Notes

Buttons for export/print are powered by DataTables.Buttons extension.

Priority checkbox and department priority link are functional UI components — backend logic not added till

for Stafftype and Priority columns are created in backednd

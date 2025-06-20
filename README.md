# Showcase API App (.NET 8)

This is a simple CRUD-style web application built with .NET 8. It allows users to:

- Create new tasks and users
- View all tasks and users
- View specific tasks and users
- Edit tasks and users
- Delete tasks and users
- Get expired tasks

---

## 🛠 Technology Stack

- **Backend**: ASP.NET 8 (API)
- **Frontend**: Swagger
- **Database**: SQL Server (configured in `appsettings.json`)
- **ORM**: Entity Framework Core (with code-first migrations)

---

## ⚙️ Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/ThatGuyWilliam/APIShowcase.git
   cd apishowcase
   ```

2. **Configure Database**
   - Open `appsettings.json`
   - Update the connection string in the `ConnectionStrings` section with your SQL Server details:
     ```json
     "ConnectionStrings": { "LocalDB": "Server=PC;Database=SkillDB;Trusted_Connection=True;TrustServerCertificate=True"},
     ```

3. **Apply EF Migrations**
   Ensure you have the .NET 8 SDK installed, then run:
   ```bash
   update-database
   ```

---

## 🧪 Features

- ✅ CRUD functionality for tasks and users

---

## 📁 Project Structure

```
/Controllers
    ApplicationDbContext.cs
    TaskController.cs
    UserController.cs
/BLL
    TaskManager.cs
    UserManager.cs
?DAL
    TaskRepo.cs
    UserRepo.cs
/Models
    Task.cs
    User.cs
```
---

## 📌 Requirements

- .NET 8 SDK
- SQL Server (LocalDB or full instance)

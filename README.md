# Event Management System

## Overview
This project is a simple event management system with CRUD (Create, Read, Update, Delete) functionality for events. It includes a backend built with **ASP.NET Core** and a frontend developed using **Angular** (standalone app structure).

---

## Technologies Used

### Backend
- **Language:** C#
- **Framework:** ASP.NET Core 9.0
- **Database:** Entity Framework Core with a SQL Server database
- **Logging:** Serilog

### Frontend
- **Framework:** Angular 19.0
- **TypeScript:** For building the application logic
- **Styling:** Custom CSS for responsive and modern design

---

## Backend Setup

### 1. Update Connection String
To configure the connection string for the database:
1. Open the `appsettings.json` file in the backend project.
2. Locate the `ConnectionStrings` section and update it to point to your SQL Server database.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=EventDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```
### 2. Run Entity Framework Migrations
If the database schema needs to be updated, use the following commands:

1. Open a terminal or command prompt in the backend project directory.
2. Add a migration (if changes have been made to the models):
  ```bash
  dotnet ef migrations add MigrationName
  ```
3. Update the database:
  ```bash
  dotnet ef database update
  ```

By default, it will be hosted on https://localhost:7244.

---

## Frontend Setup

1. Update the backend url in event-service.ts
2. Install Dependencies
   ```bash
   npm install
   ```
3. Run the Frontend
   ```bash
   ng serve
   ```

The app will be available at http://localhost:4200.

---

## Project Structure:

### Backend:

1. EventManagementData for database accessing layer.
2. EventManagementBusiness for business layer.
3. EventManagementApi for presentation layer.

### Frontend:

1. event-list: Component for displaying and managing the list of events.
2. event-form: Component for creating and editing events.

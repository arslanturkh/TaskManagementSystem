# Task Management System

A Task Management System project.

## Table of Contents

- [Overview](#overview)
- [Prerequisites](#prerequisites)
- [Backend Setup](#backend-setup)
  - [Database Configuration](#database-configuration)
  - [Running the Application](#running-the-application)
  - [Accessing Swagger UI](#accessing-swagger-ui)
- [API Documentation](#api-documentation)
- [Contributing](#contributing)
- [License](#license)

## Overview

The Task Management System is a web application that allows users to manage tasks and users. It provides a RESTful API backend built with ASP.NET Core.

## Prerequisites

### Backend Development

- **.NET SDK** (version 6.0 or later)
  - Download from: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
- **SQL Server** for the database
  - You can use SQL Server Express or any edition suitable for development.
  - Download SQL Server Express: [https://www.microsoft.com/en-us/sql-server/sql-server-downloads](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Backend Setup

## Database Configuration

The application uses Entity Framework Core with a SQL Server database.

### Update the Connection String

- Open `appsettings.json` in the `TaskManagementApp` directory.

- Update the `ConnectionStrings` section with your database details:
    ```json
    {
        "ConnectionStrings": {
        "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TaskManagementDB;Trusted_Connection=True;        MultipleActiveResultSets=true"
        }
    }

- Replace YOUR_SERVER_NAME with the name of your SQL Server instance.
- For a local SQL Server Express instance, it might be localhost\SQLEXPRESS.
- Ensure that the database TaskManagementDB exists or will be created.

### Apply Migrations
- Open a command prompt or terminal in the TaskManagementApp directory.
- Restore the dependencies:
    ```bash
    dotnet restore
    
- Install the Entity Framework Core tools if not already installed:
  ```bash
    dotnet tool install --global dotnet-ef
- Add the initial migration:

    ```bash
    dotnet ef migrations add InitialCreate
- Update the database to apply the migration:

    ```bash
    dotnet ef database update
    
### Running the Application
- Build the Project

    ```bash
    dotnet build
- Run the Application

    ```bash
    dotnet run
- Alternatively, you can run the application from Visual Studio:
    - Open the TaskManagementApp.sln solution file in Visual Studio.
    - Press F5 or click the Start button to run the application.
- Verify the Application is Running
The application should be running at https://localhost:5001 or http://localhost:5000 (the exact URL and port may vary). Check the console output to confirm the URL.

### Accessing Swagger UI
Swagger UI provides an interactive interface to test and explore the API endpoints.

Open Swagger UI in Your Browser
Navigate to https://localhost:5001/swagger/index.html or http://localhost:5000/swagger/index.html in your web browser.

Explore the API
- You can view all the available API endpoints, their request and response models, and test them directly from the browser.

Testing the API Endpoints
- **Expand an Endpoint**
    Click on an endpoint to view its details.

- **Try it Out**
    Click the Try it out button to enable the input fields.

- **Provide Input Data**
    Enter any required parameters or request body data.

- **Execute**
    Click Execute to send the request and view the response.

## API Documentation
The API provides endpoints for managing tasks and users, including CRUD operations.
### Task Endpoints
- **GET /api/TaskItems** - Retrieve all tasks.
- **GET /api/TaskItems/{id}** - Retrieve a specific task by ID.
- **POST /api/TaskItems** - Create a new task.
- **PUT /api/TaskItems/{id}** - Update an existing task.
- **DELETE /api/TaskItems/{id}** - Delete a task.
### User Endpoints
- **GET /api/Users** - Retrieve all users.
- **GET /api/Users/{id}** - Retrieve a specific user by ID.
- **POST /api/Users** - Create a new user.
- **PUT /api/Users/{id}** - Update an existing user.
- **DELETE /api/Users/{id}** - Delete a user.

### Authentication and Authorization
**Note:** Authentication has not been implemented yet. Future updates will include secure authentication mechanisms.

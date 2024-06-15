# Car Rent Web Application

This is a web application for renting Tesla cars in Mallorca. Users can create a reservation for a Tesla for a specified date range, calculate the total cost of the reservation, and store the reservation details in a database.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Backend Setup](#backend-setup)
- [Frontend Setup](#frontend-setup)
- [API Documentation](#api-documentation)
- [Usage](#usage)
- [My assumptions](#my-assumptions)

## Technologies Used


- **Backend:** ASP.NET Core, Entity Framework Core, xUnit, SQL Server
- **Frontend:** React, Axios
- **Documentation:** Swagger

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js and npm](https://nodejs.org/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or use the default localdb

## Backend Setup

1. **Clone the repository:**

   ```bash
   git clone https://github.com/BiM4Bush/CarRentWebApp.git

   cd CarRentWebApp

2. **Navigate to the backend directory:**

   ```bash
   cd CarRentWebApi
   
3. **Install the necessary packages:**

   ```bash
   dotnet restore

4. **Update the database connection string:**
    Update the connection string in appsettings.json to point to your SQL Server instance.

   ```json
      {
        "ConnectionStrings": {
            "DefaultConnection": "Server=localhost;Database=CarRentDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
        }
      }
   ```
5. **Apply migrations and update the database:**

   ```bash
    dotnet ef database update

6. **Run the application:**

   ```bash
    dotnet run

7. **Access the Swagger UI for API documentation:**
   Open your browser and navigate to http://localhost:<port>/ (replace <port> with the actual port number).


## Frontend Setup


1. **Navigate to the frontend directory:**

   ```bash
    cd car-rent

2. **Install the necessary packages:**

   ```bash
   npm install
   
3. **Run the application:**

   ```bash
   npm start

4. **Access the frontend:**
    Open your browser and navigate to http://localhost:3000.

## API Documentation

The API documentation is available via Swagger. To access it:

1.Run the backend application

2.Open your browser and navigate to http://localhost:<port>/.


## Usage

### Create a Reservation

  1.Navigate to the reservation form on the frontend (http://localhost:3000).

  2.Fill out the reservation details including car model, pickup location, return location, pickup date, and return date.

  3.Submit the form to create a reservation. The total cost will be calculated and displayed.

### Example API Calls

**Get all locations:**

   ```bash
    GET /locations
  ```
**Get all cars:**

   ```bash
    GET /cars
  ```
**Create a reservation:**

   ```bash
    POST /reservations
  {
    "carId": 1,
    "pickupDate": "2024-06-15T00:00:00",
    "returnDate": "2024-06-20T00:00:00",
    "pickupLocationId": 1,
    "returnLocationId": 2
  }
  ```

## My assumptions

1. **Completing the database:**

   I chose to use the 'Seed' method as part of migration as a way to supplement our local database with available cars and available locations. This procedure involves adding appropriate SQL operations to the migration code so that the       records are added when creating the database:
   ```bash

   migrationBuilder.Sql("INSERT INTO Cars (Model, RentCostPerDay) VALUES ('Model S', '250');");
   migrationBuilder.Sql("INSERT INTO Cars (Model, RentCostPerDay) VALUES ('Model 3', '350');");
   migrationBuilder.Sql("INSERT INTO Cars (Model, RentCostPerDay) VALUES ('Model X', '540');");
   migrationBuilder.Sql("INSERT INTO Cars (Model, RentCostPerDay) VALUES ('Model y', '260');");
   migrationBuilder.Sql("INSERT INTO Cars (Model, RentCostPerDay) VALUES ('Cybertruck', '1000');");

   migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Palma Airport');");
   migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Palma City Center');");
   migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Alcudia');");
   migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Manacor');");
   ```

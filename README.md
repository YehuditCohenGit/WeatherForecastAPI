# Weather API Service

This project is a Weather API Service that provides weather data such as average, minimum, and maximum temperatures. It is built using .NET 9 and C# 13.0.

## Prerequisites

- .NET 9 SDK
- SQL Server
- Visual Studio 2022 or later

## Setup Instructions

1. **Clone the repository:**
2. **Configure the database connection:**
   - Create Database in SQL Server using the following document: 
     https://learn.microsoft.com/en-us/azure/azure-sql/database/single-database-create-quickstart?view=azuresql
   - Open `WeatherDataLayer/WeatherDbContext.cs`.
   - Update the `SqlConnectionStringBuilder` with your SQL Server credentials.

3. **Apply Migrations:**
   - Open the Package Manager Console in the project directory.
   - Run the following commands to apply migrations:
   - First: ensure you run this command in the WeatherDataLayer project
	- add-migration <migration-name>
    - update-database
    This will create the required tables.

4. **Build the project:**
   - Open the solution in Visual Studio.
   - Build the solution by pressing `Ctrl+Shift+B`.

5. **Run the service:**
   - Press `F5` in Visual Studio to run the service.
   - The service will be available at `https://localhost:<port>`.

## API Endpoints

- **Get Average Temperature:**
  - `GET /api/weatherforecast/average-temperature`
  - Response: `double`

- **Get Minimum Temperature:**
  - `GET /api/weatherforecast/min-temperature`
  - Response: `double`

- **Get Maximum Temperature:**
  - `GET /api/weatherforecast/max-temperature`
  - Response: `double`

  - **Get Smart Temper Recommendation:**
  - `GET /api/weatherforecast/max-temperature`
  - Response: `int`, `AirConditionerMode`

# WeatherAPIService using Docker

This project is a .NET 9 application that provides weather-related services. The following instructions will guide you on how to build and run the application using Docker.

## Prerequisites

- Docker installed on your machine
- .NET 9 SDK installed on your machine

## Building and Running the Application with Docker

1. **Open Docker Desktop**:
   - Open the Docker desktop application and ensure that it is running.
2. **Build the Docker image:**
    - Open a terminal in the project directory.
    - Run the following command to build the Docker image:
      `docker build -t weather-api-service .`
3. **Run the Docker container:**
   - Run the following command to run the Docker container:
     `docker run -d -p 80:80 weather-api-service`
4. **Access the application:**
    Open your web browser and navigate to `http://localhost:80` to access the WeatherAPIService.
    Note that you can define a different port when running the Docker container if port 80 is already in use.

By following these steps, you can successfully build and run the WeatherAPIService using Docker.

## Swagger Documentation

- Swagger UI is available at `https://localhost:<port>/swagger/index.html`.
- OpenAPI documentation can be accessed at `https://localhost:<port>/swagger/v1/swagger.json`.

## Creating a SQL Database Using Azure CLI in Cloud Shell

- Open the Azure portal and click on the Cloud Shell icon in the top right corner.
- Choose either Bash or PowerShell as your preferred shell environment. For this guide, we will use Bash.
- Upload the Script: Click on the Manage Files icon and then click on upload files icon, choose the `create_sql_server.ps1` script and upload your script file.
- Run the Script: Navigate to the directory where you uploaded the script and run it. run it with the following command: `./create_sql_server.ps1`.
- Press Enter to execute the script.
- After running the script, you can verify that the resources were created successfully by navigating to the Azure portal and checking the resource group, SQL server, and SQL database.
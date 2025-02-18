# Variables
$location = "Israel Central"
$resourceGroupName = "weather-data-rg-il"
$sqlServerName = "weather-data-sql-server-il"
$sqlDatabaseName = "WeatherData"
$adminUser = "AdminUsername"
$adminPassword = "AdminPassword"

# Create a resource group
az group create --name $resourceGroupName --location $location

# Sleep for 10 milliseconds
Start-Sleep -Milliseconds 10

# Create a SQL server
az sql server create --name $sqlServerName --resource-group $resourceGroupName --location $location --admin-user $adminUser --admin-password $adminPassword

# Create a SQL database
az sql db create --resource-group $resourceGroupName --server $sqlServerName --name $sqlDatabaseName --service-objective S0
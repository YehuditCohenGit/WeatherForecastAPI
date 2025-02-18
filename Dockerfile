    # Use the official .NET 9 SDK image as a build stage
    FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
    WORKDIR /app

    # Copy the project files
    COPY . ./

    # Restore dependencies
    RUN dotnet restore

    # Build the project
    RUN dotnet publish -c Release -o out

    # Use the official .NET runtime image
    FROM mcr.microsoft.com/dotnet/aspnet:9.0
    WORKDIR /app
    COPY --from=build /app/out .

    # Expose the port the app runs on
    EXPOSE 80

    # Run the application
    ENTRYPOINT ["dotnet", "WeatherAPIService.dll"]
    
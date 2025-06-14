# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files for restore
COPY HotelsHubApp.LoggingWorkerService/*.csproj ./HotelsHubApp.LoggingWorkerService/
COPY HotelsHubApp.Core/*.csproj ./HotelsHubApp.Core/
COPY HotelsHubApp.Business/*.csproj ./HotelsHubApp.Business/
COPY HotelsHubApp.DataAccess/*.csproj ./HotelsHubApp.DataAccess/
COPY HotelsHubApp.Entities/*.csproj ./HotelsHubApp.Entities/

# Restore dependencies for Worker Service
WORKDIR /src/HotelsHubApp.LoggingWorkerService
RUN dotnet restore

# Copy source files excluding conflicting appsettings
WORKDIR /src
COPY HotelsHubApp.LoggingWorkerService/ ./HotelsHubApp.LoggingWorkerService/
COPY HotelsHubApp.Core/ ./HotelsHubApp.Core/
COPY HotelsHubApp.Business/ ./HotelsHubApp.Business/
COPY HotelsHubApp.DataAccess/ ./HotelsHubApp.DataAccess/
COPY HotelsHubApp.Entities/ ./HotelsHubApp.Entities/

# Build the application
WORKDIR /src/HotelsHubApp.LoggingWorkerService
RUN dotnet publish -c Release -o /app/publish

# Runtime stage - Use ASP.NET runtime for Core project dependencies
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "HotelsHubApp.LoggingWorkerService.dll"] 
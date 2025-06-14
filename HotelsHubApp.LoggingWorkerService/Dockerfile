# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files for restore
COPY HotelsHubApp.LoggingWorkerService/*.csproj ./HotelsHubApp.LoggingWorkerService/
COPY HotelsHubApp.Core/*.csproj ./HotelsHubApp.Core/
COPY HotelsHubApp.WebAPI/*.csproj ./HotelsHubApp.WebAPI/

# Restore dependencies for Worker Service
WORKDIR /src/HotelsHubApp.LoggingWorkerService
RUN dotnet restore

# Copy only necessary source files
WORKDIR /src
COPY HotelsHubApp.LoggingWorkerService/ ./HotelsHubApp.LoggingWorkerService/
COPY HotelsHubApp.Core/ ./HotelsHubApp.Core/

# Build the application
WORKDIR /src/HotelsHubApp.LoggingWorkerService
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "HotelsHubApp.LoggingWorkerService.dll"] 
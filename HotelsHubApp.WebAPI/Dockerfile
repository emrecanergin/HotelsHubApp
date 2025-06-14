# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy project files for restore
COPY HotelsHubApp.WebAPI/*.csproj ./HotelsHubApp.WebAPI/
COPY HotelsHubApp.Business/*.csproj ./HotelsHubApp.Business/
COPY HotelsHubApp.Core/*.csproj ./HotelsHubApp.Core/
COPY HotelsHubApp.DataAccess/*.csproj ./HotelsHubApp.DataAccess/
COPY HotelsHubApp.Entities/*.csproj ./HotelsHubApp.Entities/

# Restore dependencies for WebAPI
WORKDIR /src/HotelsHubApp.WebAPI
RUN dotnet restore

# Copy everything else
WORKDIR /src
COPY . .

# Build the application
WORKDIR /src/HotelsHubApp.WebAPI
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .



EXPOSE 80
ENTRYPOINT ["dotnet", "HotelsHubApp.WebAPI.dll"] 
# HotelsHubApp
**Web API project that queries hotel availability-price information**

## Prerequisites
- .NET 6.0 SDK
- Docker & Docker Compose

## 🚀 Quick Start

1. **Clone the repository**
```bash
git clone https://github.com/yourusername/HotelsHubApp.git
cd HotelsHubApp
```

2. **Run with your Hotelbeds API credentials**

### Windows (PowerShell) - Recommended
```powershell
.\run.ps1 -ApiKey "your_api_key" -SecretKey "your_secret_key"
```

### Linux/Mac (Bash)
```bash
HOTELBEDS_API_KEY="your_api_key" HOTELBEDS_SECRET_KEY="your_secret_key" docker-compose up --build
```

**That's it! 🚀 Everything runs automatically:**
- All infrastructure services (Redis, MongoDB, RabbitMQ, SQL Server)
- Web API with automatic database migration
- Worker Service for background logging

## Alternative: Manual Setup

If you prefer running .NET apps locally:

```bash
# 1. Start only infrastructure
docker-compose up redis mongodb rabbitmq sqlserver -d

# 2. Run .NET apps locally
dotnet run --project HotelsHubApp.WebAPI
dotnet run --project HotelsHubApp.LoggingWorkerService
```

## Services & Endpoints
- **Web API**: http://localhost:5000
- **Swagger**: http://localhost:5000/swagger
- **RabbitMQ Management**: http://localhost:15672 (guest/guest)

### API Endpoints
- **Hotel Search**: POST /hotel-api/hotels
- **Booking**: POST /hotel-api/bookings

### Infrastructure Services
- **Redis**: localhost:6379
- **MongoDB**: localhost:27017
- **RabbitMQ**: localhost:5672
- **SQL Server**: localhost:1433 (sa/YourPassword123!)

## 🔐 API Credentials

You need valid Hotelbeds API credentials to run this project. Get them from [Hotelbeds API](https://developer.hotelbeds.com/).

**⚠️ NEVER commit API keys to Git!** The run.ps1 script handles credentials securely. 
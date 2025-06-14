# HotelsHubApp
**Web API project that queries hotel availability-price information**

## Prerequisites
- .NET 6.0 SDK
- Docker & Docker Compose

## Quick Start

1. **Clone the repository**
```bash
git clone https://github.com/yourusername/HotelsHubApp.git
cd HotelsHubApp
```

2. **Start everything with Docker (recommended)**
```bash
docker-compose up --build
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

## 🔐 Security Configuration

**IMPORTANT:** Before running the project, you must configure your Hotelbeds API credentials:

### Method 1: Environment Variables (Recommended)
```bash
export HOTELBEDS_API_KEY="your_actual_api_key"
export HOTELBEDS_SECRET_KEY="your_actual_secret_key"
docker-compose up --build
```

### Method 2: Update appsettings.json
```json
{
  "Hotelbeds": {
    "ApiKey": "your_actual_api_key",
    "SecretKey": "your_actual_secret_key"
  }
}
```

**⚠️ NEVER commit real API keys to Git!** 
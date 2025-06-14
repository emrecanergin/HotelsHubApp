param(
    [Parameter(Mandatory=$true)]
    [string]$ApiKey,
    
    [Parameter(Mandatory=$true)]
    [string]$SecretKey
)

Write-Host "Starting HotelsHubApp with provided API credentials..." -ForegroundColor Green

# Set environment variables
$env:HOTELBEDS_API_KEY = $ApiKey
$env:HOTELBEDS_SECRET_KEY = $SecretKey

Write-Host "API Key: $($ApiKey.Substring(0,8))..." -ForegroundColor Yellow
Write-Host "Secret Key: $($SecretKey.Substring(0,4))..." -ForegroundColor Yellow

# Run docker-compose
Write-Host "Starting Docker containers..." -ForegroundColor Green
& docker-compose up --build 
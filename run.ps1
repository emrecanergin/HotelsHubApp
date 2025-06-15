param(
    [Parameter(Mandatory=$true)]
    [string]$ApiKey,
    
    [Parameter(Mandatory=$true)]
    [string]$SecretKey
)

Write-Host "Starting HotelsHubApp with provided API credentials..." -ForegroundColor Green

# Set environment variables for the current process
[Environment]::SetEnvironmentVariable("HOTELBEDS_API_KEY", $ApiKey, [EnvironmentVariableTarget]::Process)
[Environment]::SetEnvironmentVariable("HOTELBEDS_SECRET_KEY", $SecretKey, [EnvironmentVariableTarget]::Process)

Write-Host "API Key: $($ApiKey.Substring(0,8))..." -ForegroundColor Yellow
Write-Host "Secret Key: $($SecretKey.Substring(0,4))..." -ForegroundColor Yellow

# Run docker-compose with environment variables
Write-Host "Starting Docker containers..." -ForegroundColor Green
$env:HOTELBEDS_API_KEY = $ApiKey
$env:HOTELBEDS_SECRET_KEY = $SecretKey
& docker-compose up --build 
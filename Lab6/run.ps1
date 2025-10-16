param(
    [Parameter(Mandatory=$true)]
    [ValidateSet("Development", "Staging", "Production")]
    [string]$Environment
)

# Очищаем предыдущую сборку
Write-Host "Cleaning previous build..."
dotnet clean

# Пересобираем проект
Write-Host "Rebuilding project..."
dotnet build

# Устанавливаем переменную окружения
$env:ASPNETCORE_ENVIRONMENT = $Environment
Write-Host "Setting environment to: $Environment"

# Запускаем приложение без использования launchSettings.json
Write-Host "Starting application in $Environment environment..."
dotnet run --no-launch-profile --environment $Environment 
# Устанавливаем переменную окружения
$env:ASPNETCORE_ENVIRONMENT = "Staging"

# Проверяем, что переменная установлена
Write-Host "Current Environment: $env:ASPNETCORE_ENVIRONMENT"

# Очищаем предыдущую сборку
Write-Host "Cleaning previous build..."
dotnet clean

# Пересобираем проект
Write-Host "Rebuilding project..."
dotnet build

# Запускаем приложение
Write-Host "Starting application in Staging environment..."
dotnet run 
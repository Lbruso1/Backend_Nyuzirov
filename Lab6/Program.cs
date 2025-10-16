using Lab6.Models;

var builder = WebApplication.CreateBuilder(args);

// Проверяем все возможные источники окружения
var envFromVar = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var envFromBuilder = builder.Environment.EnvironmentName;
var envFromHost = builder.Environment.EnvironmentName;

Console.WriteLine($"Environment from variable: {envFromVar}");
Console.WriteLine($"Environment from builder: {envFromBuilder}");
Console.WriteLine($"Environment from host: {envFromHost}");

// Устанавливаем окружение
var environment = envFromVar ?? envFromBuilder;
Console.WriteLine($"Using environment: {environment}");

// Add services to the container.
builder.Services.AddRazorPages();

// Configure AppSettings
builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings"));

// Add configuration to services
var appSettings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>()
    ?? throw new InvalidOperationException("AppSettings configuration is missing or invalid");
builder.Services.AddSingleton(appSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

// Добавляем middleware для логирования окружения
app.Use(async (context, next) =>
{
    var env = context.RequestServices.GetRequiredService<IWebHostEnvironment>();
    Console.WriteLine($"Request Environment: {env.EnvironmentName}");
    Console.WriteLine($"Content Root Path: {env.ContentRootPath}");
    Console.WriteLine($"Web Root Path: {env.WebRootPath}");
    await next();
});

app.Run();

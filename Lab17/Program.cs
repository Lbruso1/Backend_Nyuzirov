using Lab17.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Добавляем различные типы кеширования
builder.Services.AddMemoryCache(); // Встроенный кэш памяти
builder.Services.AddDistributedMemoryCache(); // Распределенный кэш в памяти
builder.Services.AddStackExchangeRedisCache(options => // Распределенный кэш Redis
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "SampleInstance";
});

// Добавляем сервис для работы с кэшем
builder.Services.AddSingleton<ICacheService, CacheService>();

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

app.Run();

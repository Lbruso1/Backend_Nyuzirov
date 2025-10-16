using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab3;

/// <summary>
/// Main program class that sets up dependency injection and runs the application
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Create a host builder
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // Register services
                services.AddSingleton<IMessageService, MessageService>();
                services.AddSingleton<ApplicationService>();
            })
            .Build();

        // Get the application service and run it
        var appService = host.Services.GetRequiredService<ApplicationService>();
        appService.Run();
    }
}

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Main program
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Register services
                    services.AddSingleton<IMessageService, MessageService>();
                    services.AddSingleton<Application>();
                })
                .Build();

            // Get the application instance and run it
            var app = host.Services.GetRequiredService<Application>();
            app.Run();
        }
    }

    // Create a sample service interface
    public interface IMessageService
    {
        string GetMessage();
    }

    // Create a sample service implementation
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from dependency injection!";
        }
    }

    // Create the main application class
    public class Application
    {
        private readonly IMessageService _messageService;

        public Application(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Run()
        {
            Console.WriteLine(_messageService.GetMessage());
        }
    }
}

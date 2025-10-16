namespace Lab3;

/// <summary>
/// Main application service that coordinates the application logic
/// </summary>
public class ApplicationService
{
    private readonly IMessageService _messageService;

    public ApplicationService(IMessageService messageService)
    {
        _messageService = messageService;
    }

    public void Run()
    {
        // Display initial message
        Console.WriteLine("Initial message: " + _messageService.GetMessage());

        // Save a new message
        _messageService.SaveMessage("Updated message from ApplicationService!");

        // Display updated message
        Console.WriteLine("Updated message: " + _messageService.GetMessage());
    }
} 
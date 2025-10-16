namespace Lab3;

/// <summary>
/// Concrete implementation of IMessageService
/// </summary>
public class MessageService : IMessageService
{
    private string _currentMessage = "Hello from MessageService!";

    public string GetMessage()
    {
        return _currentMessage;
    }

    public void SaveMessage(string message)
    {
        _currentMessage = message;
    }
} 
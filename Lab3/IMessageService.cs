namespace Lab3;

/// <summary>
/// Interface for message service that handles message operations
/// </summary>
public interface IMessageService
{
    string GetMessage();
    void SaveMessage(string message);
} 
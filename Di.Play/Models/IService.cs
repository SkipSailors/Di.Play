namespace Di.Play.Models;

public interface IService
{
    string DoSomething();
}

public class Service : IService
{
    private string Message { get; }

    public Service(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentNullException(nameof(message));
        }
        
        Message = message;
    }
    
    /// <inheritdoc />
    public string DoSomething()
    {
        return Message;
    }
}
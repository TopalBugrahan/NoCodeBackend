namespace KouMobilio.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base("Entity not found")
    {
        
    }

    public NotFoundException(string message) : base(message)
    {
        
    }

    public NotFoundException(string entityName, object key) : base($"{entityName} ({key}) was not found.")
    {

    }
}
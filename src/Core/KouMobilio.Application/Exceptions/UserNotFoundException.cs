namespace KouMobilio.Application.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Invalid username or password")
    {
        
    }
}
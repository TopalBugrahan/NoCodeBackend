namespace KouMobilio.Application.Exceptions;

public class UserAlreadyExistsException: Exception
{
    public UserAlreadyExistsException() : base("User already exists")
    {
        
    }
}
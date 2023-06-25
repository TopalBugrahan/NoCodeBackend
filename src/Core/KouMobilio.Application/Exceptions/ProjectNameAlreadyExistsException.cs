namespace KouMobilio.Application.Exceptions;

public class ProjectNameAlreadyExistsException : Exception
{
    public ProjectNameAlreadyExistsException(string name) : base($"There is already a project named '{name}'")
    {
        
    }
}
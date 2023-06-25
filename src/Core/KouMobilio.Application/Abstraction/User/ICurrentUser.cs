namespace KouMobilio.Application.Abstraction.User;

public interface ICurrentUser
{
    public Guid Id { get;}
    public string NameSurname { get;}
    public string Email { get; }
}
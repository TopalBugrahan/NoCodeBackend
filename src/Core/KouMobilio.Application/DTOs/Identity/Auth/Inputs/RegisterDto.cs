namespace KouMobilio.Application.DTOs.Identity.Auth.Inputs;

public class RegisterDto
{
    public string NameSurname { get; set; }
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}
namespace KouMobilio.Application.DTOs.Identity.Auth.Inputs;

public class LoginDto
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}
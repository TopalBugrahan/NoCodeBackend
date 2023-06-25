namespace KouMobilio.Application.DTOs.Identity.Auth.Outputs;

public class TokenDto
{
    public string AccessToken { get; set; }
    public DateTime ExpirationTime { get; set; }
}
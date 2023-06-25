using KouMobilio.Application.DTOs.Identity.Auth.Inputs;
using KouMobilio.Application.DTOs.Identity.Auth.Outputs;

namespace KouMobilio.Application.Abstraction.Services;

public interface IAuthService
{
    Task<TokenDto> LoginAsync(LoginDto input);
    Task<TokenDto> RegisterAsync(RegisterDto input);
}
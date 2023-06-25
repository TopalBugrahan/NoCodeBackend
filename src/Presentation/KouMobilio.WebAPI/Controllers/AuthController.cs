using KouMobilio.Application.Abstraction.Services;
using KouMobilio.Application.DTOs.Identity.Auth.Inputs;
using KouMobilio.Application.DTOs.Identity.Auth.Outputs;
using Microsoft.AspNetCore.Mvc;

namespace KouMobilio.WebAPI.Controllers;

[Route("auth")]
public class AuthController : BaseController, IAuthService
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public Task<TokenDto> LoginAsync([FromBody] LoginDto input)
    {
        return _authService.LoginAsync(input);
    }
    
    [HttpPost("register")]
    public Task<TokenDto> RegisterAsync([FromBody] RegisterDto input)
    {
        return _authService.RegisterAsync(input);
    }
}
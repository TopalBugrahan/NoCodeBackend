using KouMobilio.Application.Abstraction.Services;
using KouMobilio.Application.Abstraction.Token;
using KouMobilio.Application.DTOs.Identity.Auth.Inputs;
using KouMobilio.Application.DTOs.Identity.Auth.Outputs;
using KouMobilio.Application.Exceptions;
using KouMobilio.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace KouMobile.Persistence.Services;

public class AuthService : IAuthService
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly ITokenHandler _tokenHandler;

    public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ITokenHandler tokenHandler)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _tokenHandler = tokenHandler;
    }

    public async Task<TokenDto> LoginAsync(LoginDto input)
    {
        var user = await _userManager.FindByNameAsync(input.UsernameOrEmail) ?? await _userManager.FindByEmailAsync(input.UsernameOrEmail);
        if (user == null)
        {
            throw new UserNotFoundException();
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
        if (!signInResult.Succeeded)
            throw new UserNotFoundException();

        return _tokenHandler.CreateAccessToken(5, user);
    }
    
    public async Task<TokenDto> RegisterAsync(RegisterDto input)
    {
        var user = await _userManager.FindByEmailAsync(input.UsernameOrEmail);
        if (user != null)
        {
            throw new UserAlreadyExistsException();
        }

        user = new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = input.UsernameOrEmail,
            Email = input.UsernameOrEmail,
            NameSurname = input.NameSurname,

        };
        var result = await _userManager.CreateAsync(user, input.Password);
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
        
        await _signInManager.SignInAsync(user, false);
        return _tokenHandler.CreateAccessToken(5, user);
    }
}
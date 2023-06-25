using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KouMobilio.Application.Abstraction.Token;
using KouMobilio.Application.DTOs.Identity.Auth.Outputs;
using KouMobilio.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace KouMobile.Infrastructure.Services.Token;

public class TokenHandler : ITokenHandler
{
    private IConfiguration _configuration;

    public TokenHandler(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TokenDto CreateAccessToken(int minute, AppUser user)
    {
        var token = new TokenDto();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        token.ExpirationTime = DateTime.UtcNow.AddMinutes(minute);

        var jwtToken = new JwtSecurityToken(
            audience: _configuration["Token:Audience"],
            issuer: _configuration["Token:Issuer"], 
            expires: token.ExpirationTime, 
            notBefore: DateTime.UtcNow, 
            signingCredentials: signingCredentials,
            claims: new List<Claim>
            {
                new(ClaimTypes.Name, user.NameSurname),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.Id),
            });

        var jwtTokenHandler = new JwtSecurityTokenHandler();
        token.AccessToken = jwtTokenHandler.WriteToken(jwtToken);
        return token;
    }
}
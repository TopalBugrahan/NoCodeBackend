using KouMobilio.Application.DTOs.Identity.Auth.Outputs;
using KouMobilio.Domain.Entities.Identity;

namespace KouMobilio.Application.Abstraction.Token;

public interface ITokenHandler
{
    TokenDto CreateAccessToken(int minute, AppUser user);
}
using System.Security.Claims;
using KouMobilio.Application.Abstraction.User;
using Microsoft.AspNetCore.Http;

namespace KouMobile.Infrastructure.User;

public class CurrentUser : ICurrentUser
{
    public Guid Id {get
    {
        var userIdString = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (Guid.TryParse(userIdString, out Guid userId))
        {
            return userId;
        }

        return Guid.Empty;
    } } 
    public string NameSurname => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

    public string Email => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

    private IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}
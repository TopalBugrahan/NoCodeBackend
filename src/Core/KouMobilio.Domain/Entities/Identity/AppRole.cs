using Microsoft.AspNetCore.Identity;

namespace KouMobilio.Domain.Entities.Identity;

public class AppRole : IdentityRole<string>
{
    public AppRole()
    {
        
    }
    public AppRole(string role) : base(role)
    {
        
    }
}
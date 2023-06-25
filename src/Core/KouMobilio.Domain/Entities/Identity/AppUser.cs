using Microsoft.AspNetCore.Identity;

namespace KouMobilio.Domain.Entities.Identity;

public class AppUser : IdentityUser<string>
{
    public string NameSurname { get; set; }
}
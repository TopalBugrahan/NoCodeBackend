using KouMobilio.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KouMobile.Persistence.Seed;

public class IdentitySeed
{
    private readonly ModelBuilder _builder;

    public IdentitySeed(ModelBuilder builder)
    {
        _builder = builder;
    }

    public void Seed()
    {
        //Roles   
        var adminRole = new AppRole("Admin");
        adminRole.Id = Guid.NewGuid().ToString();
        adminRole.NormalizedName = adminRole.Name.ToUpper();
        
        var memberRole = new AppRole("Member");
        memberRole.Id = Guid.NewGuid().ToString();
        memberRole.NormalizedName = memberRole.Name.ToUpper();

        _builder.Entity<AppRole>().HasData(new List<AppRole>()
        {
            adminRole,
            memberRole
        });
        
        
        //Users

        var passwordHasher = new PasswordHasher<AppUser>();

        var adminUser = new AppUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "admin",
            Email = "admin@koumobilio.com",
            EmailConfirmed = true,
            NameSurname = "Koumobilio Admin"
        };
        adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
        adminUser.NormalizedEmail = adminUser.Email.ToUpper();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "123456");
        
        var memberUser = new AppUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "member",
            Email = "member@koumobilio.com",
            EmailConfirmed = true,
            NameSurname = "Koumobilio Member"
        };
        memberUser.NormalizedUserName = memberUser.UserName.ToUpper();
        memberUser.NormalizedEmail = memberUser.Email.ToUpper();
        memberUser.PasswordHash = passwordHasher.HashPassword(memberUser, "123456");

        _builder.Entity<AppUser>().HasData(new List<AppUser>()
        {
            adminUser,
            memberUser
        });
        
        // User Roles

        var userRoles = new List<IdentityUserRole<string>>()
        {
            new()
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            },
            new()
            {
                UserId = memberUser.Id,
                RoleId = memberRole.Id
            }
        };
        
        _builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}
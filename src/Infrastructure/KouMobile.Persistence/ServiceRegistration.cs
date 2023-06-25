using KouMobile.Persistence.Contexts;
using KouMobile.Persistence.Repositories;
using KouMobile.Persistence.Services;
using KouMobilio.Application.Abstraction.Services;
using KouMobilio.Application.Repositories;
using KouMobilio.Domain.Entities;
using KouMobilio.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KouMobile.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {

        //DbContext
        services.AddDbContext<KouMobilioDbContext>(options =>
            options.UseNpgsql(Configuration.ConnectionString));

        //Identity
        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
        }).AddEntityFrameworkStores<KouMobilioDbContext>();
        
        //Repositories
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IRestServiceConfigRepository, RestServiceConfigRepository>();
        
        //Services
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IAuthService, AuthService>();
        
        return services;
    }
}
using KouMobile.Infrastructure.Services.Token;
using KouMobilio.Application.Abstraction.Services;
using KouMobilio.Application.Abstraction.Token;
using KouMobilio.Application.Repositories;
using KouMobilio.Domain.Entities.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace KouMobile.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<ITokenHandler, TokenHandler>();
        return services;
    }
}
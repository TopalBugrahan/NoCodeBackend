using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using KouMobilio.Application.Validators.Projects;
using Microsoft.Extensions.DependencyInjection;

namespace KouMobilio.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        
        //Validator
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(assembly);
        
        //Mapping
        services.AddAutoMapper(assembly);
        
        return services;
    }
}
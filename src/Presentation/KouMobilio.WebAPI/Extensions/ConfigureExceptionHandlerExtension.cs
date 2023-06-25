using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics;

namespace KouMobilio.WebAPI.Extensions;

public static class ConfigureExceptionHandlerExtension
{
    public static void ConfigureKouMobilioExceptionHandler(this WebApplication application)
    {
        application.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Messages = new []
                        {
                            contextFeature.Error.Message
                        }
                    });
                }

            });
        });
    }
}
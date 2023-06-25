using Microsoft.Extensions.Configuration;

namespace KouMobile.Persistence;

static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/KouMobilio.WebAPI"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json");

            return configurationManager.GetConnectionString("PostgreSQL");
        }
    }
}
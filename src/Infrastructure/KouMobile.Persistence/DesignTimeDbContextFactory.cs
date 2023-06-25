using KouMobile.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace KouMobile.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<KouMobilioDbContext>
{
    public KouMobilioDbContext CreateDbContext(string[] args)
    {   
        DbContextOptionsBuilder<KouMobilioDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);

        return new KouMobilioDbContext(dbContextOptionsBuilder.Options, null);
    }
}
using Microsoft.EntityFrameworkCore;

namespace KouMobile.Persistence.Seed;

public static class Seeder
{
    public static void Seed(this ModelBuilder builder)
    {
        var identitySeed = new IdentitySeed(builder);
        identitySeed.Seed();
    }
}
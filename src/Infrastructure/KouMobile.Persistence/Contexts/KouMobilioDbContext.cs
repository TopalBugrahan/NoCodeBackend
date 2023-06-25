using KouMobile.Persistence.Seed;
using KouMobilio.Application.Abstraction.User;
using KouMobilio.Domain.Entities;
using KouMobilio.Domain.Entities.Common;
using KouMobilio.Domain.Entities.Identity;
using KouMobilio.Domain.Entities.RestService;
using KouMobilio.Domain.Entities.RestService.ValueObjects;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KouMobile.Persistence.Contexts;

public class KouMobilioDbContext : IdentityDbContext<AppUser, AppRole, string>
{
    private readonly ICurrentUser _currentUser;
    public KouMobilioDbContext(DbContextOptions options, ICurrentUser currentUser) : base(options)
    {
        _currentUser = currentUser;
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<RestServiceConfig> RestServiceConfigs { get; set; }
    public DbSet<Endpoint> Endpoints { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var datas = ChangeTracker.Entries<BaseEntity>();
        foreach (var data in datas)
        {
            if (data.State == EntityState.Added)
            {
                data.Entity.CreatedDate = DateTime.UtcNow;
                data.Entity.CreatorId = _currentUser.Id;
            }
            else if (data.State == EntityState.Modified)
            {
                data.Entity.UpdatedDate = DateTime.UtcNow;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Seed();
        
        builder.Entity<Project>(e =>
        {
            e.HasQueryFilter(p => p.CreatorId == _currentUser.Id);
        });

        builder.Entity<RestServiceConfig>(e =>
        {
            e.HasOne<Project>()
                .WithOne()
                .HasForeignKey<RestServiceConfig>(x => x.ProjectId);

            e.Navigation(x => x.Endpoints).AutoInclude();
            e.Navigation(x => x.Parameters).AutoInclude();
        });
            

        builder.Entity<Endpoint>(e =>
        {
            e.HasOne(c => c.Config)
                .WithMany(d => d.Endpoints)
                .HasForeignKey(x => x.RestServiceConfigId);

            e.Property(x => x.Url).HasConversion(x => x.ToLower(), x => x);
        });

        builder.Entity<HttpParameter>(e =>
        {
            e.Property<Guid>("Id").IsRequired();
            e.HasKey("Id");
            
            e.HasOne<RestServiceConfig>()
                .WithMany(x => x.Parameters)
                .HasForeignKey(x => x.RestServiceConfigId);
        });
        
        base.OnModelCreating(builder);
    }
}
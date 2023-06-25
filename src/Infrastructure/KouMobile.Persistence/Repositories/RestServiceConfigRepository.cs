using KouMobile.Persistence.Contexts;
using KouMobilio.Application.Abstraction.Services;
using KouMobilio.Application.Repositories;
using KouMobilio.Domain.Entities;
using KouMobilio.Domain.Entities.RestService;

namespace KouMobile.Persistence.Repositories;

public class RestServiceConfigRepository : GenericRepository<RestServiceConfig>, IRestServiceConfigRepository
{
    public RestServiceConfigRepository(KouMobilioDbContext dbContext) : base(dbContext)
    {
    }
}
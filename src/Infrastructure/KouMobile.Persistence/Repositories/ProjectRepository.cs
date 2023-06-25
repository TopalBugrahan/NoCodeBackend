using KouMobile.Persistence.Contexts;
using KouMobilio.Application.Repositories;
using KouMobilio.Domain.Entities;

namespace KouMobile.Persistence.Repositories;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(KouMobilioDbContext dbContext) : base(dbContext)
    {
    }
}
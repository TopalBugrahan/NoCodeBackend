using System.Linq.Expressions;
using KouMobile.Persistence.Contexts;
using KouMobilio.Application.Repositories;
using KouMobilio.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace KouMobile.Persistence.Repositories;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly KouMobilioDbContext _dbContext;

    public GenericRepository(KouMobilioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public DbSet<T> Table => _dbContext.Set<T>();

    public Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? method = null)
    {
        IQueryable<T> query = Table.AsNoTracking();
        
        if (method != null)
        {
            query = query.Where(method);
        }

        return query.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> method)
        => await Table.FirstOrDefaultAsync(method);

    public async Task<T> GetByIdAsync(Guid id)
        => await Table.FindAsync(id);

    public async Task<Guid> AddAsync(T model, bool autoSave)
    {
        var savedEntity = (await Table.AddAsync(model)).Entity;
        if (autoSave)
        {
            await _dbContext.SaveChangesAsync();
        }
        return savedEntity.Id;
    }

    public async Task<bool> UpdateAsync(T model, bool autoSave)
    {
        var entityEntry = Table.Update(model);
        if (autoSave)
        {
            await _dbContext.SaveChangesAsync();
        }

        return entityEntry.State == EntityState.Modified;
    }

    public async Task<bool> RemoveAsync(Guid id, bool autoSave)
    {
        var entity = await Table.FirstOrDefaultAsync(e => e.Id == id);
        var entityEntry = Table.Remove(entity);
        if (autoSave)
        {
            await _dbContext.SaveChangesAsync();
        }

        return entityEntry.State == EntityState.Deleted;
    }

    public Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();
}
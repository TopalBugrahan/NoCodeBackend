using System.Linq.Expressions;
using KouMobilio.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace KouMobilio.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
    
    
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? method = null);
    Task<T> GetAsync(Expression<Func<T, bool>> method);
    Task<T> GetByIdAsync(Guid id);
    
    Task<Guid> AddAsync(T model, bool autoSave = false);
    Task<bool> UpdateAsync(T model, bool autoSave = false);
    Task<bool> RemoveAsync(Guid id, bool autoSave = false);
    Task<int> SaveChangesAsync();
}
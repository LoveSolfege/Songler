using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>?> GetAllAsync(int start, int limit);
    Task<TEntity?> GetByIdAsync(string id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(string id, TEntity entity);
    Task<bool> DeleteAsync(string id);
}
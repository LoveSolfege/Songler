using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<IEnumerable<TEntity>?> GetAllAsync(int start, int limit);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(Guid id, TEntity entity);
    Task<bool> DeleteAsync(Guid id);
}
using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<IReadOnlyList<TEntity>?> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<bool> UpdateAsync(int id, TEntity entity);
    Task<bool> DeleteAsync(int id);
}
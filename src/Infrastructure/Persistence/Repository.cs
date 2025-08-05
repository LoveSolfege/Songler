using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly DbSet<TEntity> _dbSet;

    public Repository(SongDbContext context)
    {
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>?> GetAllAsync(int page, int pageSize)
    {
        return await _dbSet.ToListAsync();    
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<bool> UpdateAsync(Guid id, TEntity entity)
    {
        var entry = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        if(entry is null) return false;
        
        _dbSet.Update(entity);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entry = await _dbSet.FindAsync(id);
        switch (entry)
        {
            case null:
                return false;
            case IDeletable deletable:
                deletable.IsDeleted = true;
                return true;
            default:
                throw new InvalidOperationException($"Entity of type '{typeof(TEntity).Name}' with ID '{id}' does not support soft deletion.");
        }
    }
    
}
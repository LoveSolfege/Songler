using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity 
{
    private readonly SongDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(SongDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<IReadOnlyList<TEntity>?> GetAllAsync()
    {
        return await _dbSet.ToListAsync();    
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<bool> UpdateAsync(int id, TEntity entity)
    {
        var entry = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        if(entry is null) return false;
        
        _dbSet.Update(entity);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entry = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        if(entry is null) return false;
        
        entry.IsDeleted = true;
        return true;
    }
    
}
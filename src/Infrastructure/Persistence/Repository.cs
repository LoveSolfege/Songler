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

    public async Task<IEnumerable<TEntity>?> GetAllAsync(int page, int pageSize)
    {
        return await _dbSet.ToListAsync();    
    }

    public async Task<TEntity?> GetByIdAsync(string id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<bool> UpdateAsync(string id, TEntity entity)
    {
        var entry = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        if(entry is null) return false;
        
        _dbSet.Update(entity);
        return true;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var entry = await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        if(entry is null) return false;
        
        entry.IsDeleted = true;
        return true;
    }
    
}
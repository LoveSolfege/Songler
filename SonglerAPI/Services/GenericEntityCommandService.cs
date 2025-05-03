using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SonglerAPI.Entities;

namespace SonglerAPI.Services;

public class GenericEntityCommandService<TEntity, TCreateDto, TResponseDto>(DbContext ctx, IMapper mapper) :
    IGenericEntityCommandService<TEntity, TCreateDto, TResponseDto>
    where TEntity : class, IEntity
    where TCreateDto : class
    where TResponseDto : class
{
    // GET all entities
    public async Task<IEnumerable<TResponseDto>> GetAllAsync()
    {
        var entities = await ctx.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();
        
        return mapper.Map<IEnumerable<TResponseDto>>(entities);
    }

    // GET single entity by ID
    public virtual async Task<TResponseDto?> GetByIdAsync(int id)
    { 
        var entity = await ctx.Set<TEntity>()
            .AsNoTracking()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        
        return mapper.Map<TResponseDto>(entity);
    }

    // POST new entity
    public async Task<TResponseDto> CreateAsync(TCreateDto updateDto)
    {
        var entity = mapper.Map<TEntity>(updateDto);
        ctx.Set<TEntity>().Add(entity);
        await ctx.SaveChangesAsync();
        
        var response = mapper.Map<TResponseDto>(entity);
        
        return response;
    }

    // PUT entity by id
    public async Task<bool> UpdateAsync(int id, TCreateDto updateDto)
    {
        var entity = await ctx.Set<TEntity>()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        
        if(entity == null) return false;
        
        mapper.Map(updateDto, entity);
        await ctx.SaveChangesAsync();
        
        return true;
    }

    
    /// <summary>
    /// Delete or Restore entity by ID
    /// </summary>
    /// <param name="id">Entry ID to restore or delete</param>
    /// <param name="delete">if TRUE soft deletes entity, if FALSE restores it</param>
    /// <returns></returns>
    public async Task<bool> DeleteOrRestoreAsync(int id, bool delete)
    {
        var entity = await ctx.Set<TEntity>()
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync();
        
        if(entity == null) return false;
        
        entity.IsDeleted = !delete;
        await ctx.SaveChangesAsync();
        
        return true;
    }
    
}
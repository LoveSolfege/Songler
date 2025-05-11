using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SonglerAPI.Entities;
using SonglerAPI.Repository;

namespace SonglerAPI.Services.Generics;

public static class Commands
{

	public static async Task<List<TResponseDto>> GetAll<TEntity, TResponseDto>(DbContext ctx, IMapper mapper, CancellationToken ct)
	where TEntity : class
	where TResponseDto : class
	{
		return await ctx.Set<TEntity>()
			.AsNoTracking()
			.ProjectTo<TResponseDto>(mapper.ConfigurationProvider)
			.ToListAsync(ct);
	}
	
	
	public static async Task<bool> RestoreOrDeleteAsync<TEntity>(DbContext ctx, int id, bool delete, CancellationToken ct)
	where TEntity : class, IEntity{
		var entity = await ctx.Set<TEntity>()
			.Where(e => e.Id == id)
			.FirstOrDefaultAsync(ct);
        
		if(entity == null) return false;
        
		entity.IsDeleted = delete;
		await ctx.SaveChangesAsync(ct);
        
		return true;
	}
}
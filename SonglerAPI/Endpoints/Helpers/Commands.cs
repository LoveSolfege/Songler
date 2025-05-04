using Microsoft.EntityFrameworkCore;
using SonglerAPI.Entities;
using SonglerAPI.Repository;

namespace SonglerAPI.Endpoints.Helpers;

public class Commands
{
	public static async Task<bool> RestoreOrDeleteAsync<TEntity>(SongContext ctx, int id, bool delete)
	where TEntity : class, IEntity{
		var entity = await ctx.Set<TEntity>()
			.Where(e => e.Id == id)
			.FirstOrDefaultAsync();
        
		if(entity == null) return false;
        
		entity.IsDeleted = delete;
		await ctx.SaveChangesAsync();
        
		return true;
	}
}
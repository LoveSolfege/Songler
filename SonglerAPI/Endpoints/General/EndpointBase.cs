using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using SonglerAPI.Repository;

namespace SonglerAPI.Endpoints.General;

public static class EndpointBase
{
	public static RouteGroupBuilder MapCrudEndpoints<TEntity, TCreateDto, TResponseDto>(
		this WebApplication app,
		string route,
		string tag,
		Func<SongContext, DbSet<TEntity>> getDbSet)
		where TEntity : class
	{
		var group = app.MapGroup(route).WithTags(tag);
		
		//GET all entries
		group.MapGet("/", async (SongContext ctx, IMapper mapper) =>
		{
			var entities = await getDbSet(ctx)
				.AsNoTracking().
				ToListAsync();
			
			return Results.Ok(mapper.Map<List<TResponseDto>>(entities));
		});
		
		return group;
	}
}
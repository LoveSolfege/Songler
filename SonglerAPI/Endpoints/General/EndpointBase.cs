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
		//create endpoint group
		var group = app.MapGroup(route).WithTags(tag);
		
		//GET all entries
		group.MapGet("/", async (SongContext ctx, IMapper mapper) =>
		{
			var entities = await getDbSet(ctx)
				.AsNoTracking()
				.ToListAsync();
			
			return Results.Ok(mapper.Map<List<TResponseDto>>(entities));
		});

		
		//GET entry by ID
		group.MapGet("/{id:int}", async (int id, SongContext ctx, IMapper mapper) =>
		{
			var entity = await getDbSet(ctx)
				.FindAsync(id);
			
			return entity is null ? Results.NotFound() : Results.Ok(mapper.Map<TResponseDto>(entity));
		});
		
		/*
		group.MapPost("/new", async (TCreateDto dto, SongContext ctx, IMapper mapper) =>
		{
			var entity = mapper.Map<TEntity>(dto);
			ctx.Add(entity);
			await ctx.SaveChangesAsync();
			
			var responseDto = mapper.Map<TResponseDto>(entity);
			
			return Results.Created($"{route}/{entity}", responseDto);
		});
		*/
		return group;
	}
}
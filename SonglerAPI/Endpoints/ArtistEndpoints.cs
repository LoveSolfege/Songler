using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SonglerAPI.DTO.Create;
using SonglerAPI.DTO.Response;
using SonglerAPI.Endpoints.Helpers;
using SonglerAPI.Entities;
using SonglerAPI.Repository;

namespace SonglerAPI.Endpoints;

public static class ArtistEndpoints
{
	public static WebApplication MapArtistEndpoints(this WebApplication app)
	{
		var group = app.MapGroup("/artists");
		
		
		// GET all artists
		group.MapGet("/", async (SongContext ctx, IMapper mapper, CancellationToken ct) =>
		{
			var artists = await ctx.Set<Artist>()
				.AsNoTracking()
				.ToListAsync(ct);

			return artists.Count != 0 
				? Results.Ok(mapper.Map<List<ArtistResponseDto>>(artists)) 
				: Results.NoContent();
		});
		
		// GET artist by ID
		group.MapGet("/{artistId:int}", async (int artistId, SongContext ctx, IMapper mapper, CancellationToken ct) =>
		{
			var artist = await ctx.Set<Artist>()
				.AsNoTracking()
				.Where(e => e.Id == artistId)
				.FirstOrDefaultAsync(ct);
        
			return artist is not null 
				? Results.Ok(mapper.Map<ArtistResponseDto>(artist))
				: Results.NotFound();
		});
		
		// POST new artist
		group.MapPost("/", async (ArtistCreateDto dto, SongContext ctx, IMapper mapper) =>
		{
			var artist = mapper.Map<Artist>(dto);
			ctx.Set<Artist>().Add(artist);
			await ctx.SaveChangesAsync();
        
			var response = mapper.Map<ArtistResponseDto>(artist);
        
			return Results.Created($"/artists/{artist.Id}", response);
		});

		// PUT updated artist by ID
		group.MapPut("/{artistId:int}", async (int artistId, ArtistCreateDto dto, SongContext ctx, IMapper mapper, CancellationToken ct) =>
		{
				var entity = await ctx.Set<Artist>()
					.Where(e => e.Id == artistId)
					.FirstOrDefaultAsync(ct);
        
				if(entity == null) return Results.NotFound();
        
				mapper.Map(dto, entity);
				await ctx.SaveChangesAsync(ct);
        
				return Results.NoContent();
		});

		
		// DELETE artist by ID
		group.MapDelete("/{artistId:int}", async (int artistId, SongContext ctx) =>
			await Commands.RestoreOrDeleteAsync<Artist>(ctx, artistId, true) 
				? Results.NoContent() 
				: Results.NotFound());
		
		// PATCH restore artist by ID
		group.MapPatch("/{artistId:int}", async (int artistId, SongContext ctx) =>
			await Commands.RestoreOrDeleteAsync<Artist>(ctx, artistId, false) 
				? Results.NoContent() 
				: Results.NotFound());
		
		
		return app;
	}
}
using AutoMapper;
using SonglerAPI.DTO.Create;
using SonglerAPI.DTO.Response;
using SonglerAPI.Repository;
using SonglerAPI.Services;

namespace SonglerAPI.Endpoints;

public static class ArtistEndpoints
{
	public static WebApplication MapArtistEndpoints(this WebApplication app)
	{
		var svc = app.Services.GetRequiredService<ArtistEndpointService>();
		var group = app.MapGroup("/artists");
		
		
		// GET all artists
		group.MapGet("/", async (SongContext ctx, IMapper mapper, CancellationToken ct) =>
		{
			var artists = await svc.GetAllAsync(ctx, mapper, ct);

			return artists.Count > 0 
				? Results.Ok(artists) 
				: Results.NoContent();
		});
		
		// GET artist by ID
		group.MapGet("/{artistId:int}", async (int artistId, SongContext ctx, IMapper mapper, CancellationToken ct) =>
		{
			var artist = await svc.GetByIdAsync(artistId, ctx, mapper, ct);
        
			return artist is not null 
				? Results.Ok(artist)
				: Results.NotFound();
		});
		
		// POST new artist
		group.MapPost("/", async (ArtistCreateDto dto, SongContext ctx, IMapper mapper, CancellationToken ct) =>
		{
			(int id, ArtistResponseDto response) = await svc.CreateAsync(dto, ctx, mapper, ct);
			
			return Results.Created($"/artists/{id}", response);
		});

		// PUT updated artist by ID
		group.MapPut("/{artistId:int}", async (int artistId, ArtistCreateDto dto, SongContext ctx, IMapper mapper, CancellationToken ct) 
			=> await svc.UpdateAsync(artistId, dto, ctx, mapper, ct)
			? Results.NoContent()
			: Results.NotFound($"artist {artistId} not found"));

		
		// DELETE artist by ID
		group.MapDelete("/{artistId:int}", async (int artistId, SongContext ctx, CancellationToken ct) 
			=> await svc.DeleteAsync(artistId, ctx, ct)
				? Results.NoContent() 
				: Results.NotFound());
		
		// PATCH restore artist by ID
		group.MapPatch("/{artistId:int}", async (int artistId, SongContext ctx, CancellationToken ct)
			=> await svc.RestoreAsync(artistId, ctx, ct)
				? Results.NoContent() 
				: Results.NotFound());
		
		
		return app;
	}
}
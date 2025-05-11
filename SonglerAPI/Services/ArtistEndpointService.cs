using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SonglerAPI.DTO.Create;
using SonglerAPI.DTO.Response;
using SonglerAPI.Entities;
using SonglerAPI.Services.Generics;

namespace SonglerAPI.Services;

public class ArtistEndpointService : IEndpointService<Artist, ArtistCreateDto, ArtistResponseDto>
{
	public async Task<List<ArtistResponseDto>> GetAllAsync(DbContext ctx, IMapper mapper, CancellationToken ct)
	{
		return await Commands.GetAll<Artist, ArtistResponseDto>(ctx, mapper, ct);
	}

	public async Task<ArtistResponseDto?> GetByIdAsync(int id, DbContext ctx, IMapper mapper, CancellationToken ct)
	{
		return await ctx.Set<Artist>()
			.AsNoTracking()
			.Where(x => x.Id == id)
			.ProjectTo<ArtistResponseDto>(mapper.ConfigurationProvider)
			.SingleOrDefaultAsync(ct);
	}

	public async Task<(int, ArtistResponseDto)> CreateAsync(ArtistCreateDto dto, DbContext ctx, IMapper mapper,
		CancellationToken ct)
	{
		var artist = mapper.Map<Artist>(dto);
		ctx.Set<Artist>().Add(artist);
		await ctx.SaveChangesAsync(ct);
		
		var response = await ctx.Set<Artist>()
			.AsNoTracking()
			.Where(e => e.Id == artist.Id)
			.Include(a => a.Albums)
			.ThenInclude(al => al.Songs)
			.ProjectTo<ArtistResponseDto>(mapper.ConfigurationProvider)
			.FirstAsync(ct);
		
		return (artist.Id, response);
	}

	public async Task<bool> UpdateAsync(int id, ArtistCreateDto dto, DbContext ctx, IMapper mapper, CancellationToken ct)
	{
		var entity = await ctx.Set<Artist>()
			.Where(e => e.Id == id)
			.FirstOrDefaultAsync(ct);
		
		if(entity is null) return false;
		
		mapper.Map(dto, entity);
		await ctx.SaveChangesAsync(ct);
		
		return true;
	}

	public async Task<bool> DeleteAsync(int id, DbContext ctx, CancellationToken ct)
	{
		return await Commands.RestoreOrDeleteAsync<Artist>(ctx, id, true, ct);
	}

	public async Task<bool> RestoreAsync(int id, DbContext ctx, CancellationToken ct)
	{
		return await Commands.RestoreOrDeleteAsync<Artist>(ctx, id, false, ct);
	}
}
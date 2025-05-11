using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace SonglerAPI.Services;

public interface IEndpointService<in TEntity, in TCreateDto, TResponseDto>
{
	Task<List<TResponseDto>> GetAllAsync(DbContext ctx, IMapper mapper, CancellationToken ct);
	Task<TResponseDto?> GetByIdAsync(int id, DbContext ctx, IMapper mapper, CancellationToken ct);
	Task<(int, TResponseDto)> CreateAsync(TCreateDto dto, DbContext ctx, IMapper mapper, CancellationToken ct);
	Task<bool> UpdateAsync (int id, TCreateDto dto, DbContext ctx, IMapper mapper, CancellationToken ct);
	Task<bool> DeleteAsync(int id, DbContext ctx, CancellationToken ct);
	Task<bool> RestoreAsync(int id, DbContext ctx, CancellationToken ct);
}
using SonglerAPI.Entities;

namespace SonglerAPI.Services;

public interface IGenericEntityCommandService<TEntity, TCreateDto, TResponseDto>
where TEntity : class, IEntity
where TCreateDto : class
where TResponseDto : class
{
    Task<IEnumerable<TResponseDto>> GetAllAsync();
    Task<TResponseDto?> GetByIdAsync(int id);
    Task<TResponseDto> CreateAsync(TCreateDto createDto);
    Task<bool> UpdateAsync(int id, TCreateDto updateDto);
    Task<bool> DeleteOrRestoreAsync(int id, bool delete);
}
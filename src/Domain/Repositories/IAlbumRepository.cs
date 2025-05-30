using Domain.Entities;

namespace Domain.Repositories;

public interface IAlbumRepository
{
    Task<List<Album>> GetAllAsync();
    Task<Album> GetByCompositeIdAsync(int artistId, int albumId);
    Task<Album> AddAsync(int artistId, Album album);
    Task<bool> UpdateAsync(int artistId, int albumId, Album album);
    Task<bool> DeleteAsync(int artistId, int albumId);
}
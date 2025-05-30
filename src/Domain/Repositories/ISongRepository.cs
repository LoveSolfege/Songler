using Domain.Entities;

namespace Domain.Repositories;

public interface ISongRepository
{
    Task<List<Song>> GetAllAsync();
    Task<Song> GetByCompositeIdAsync(int artistId, int albumId, int songId);
    Task<Song> AddAsync(int artistId, int albumId, Song song);
    Task<bool> UpdateAsync(int artistId, int albumId, int songId, Song song);
    Task<bool> DeleteAsync(int artistId, int albumId, int songId);
}
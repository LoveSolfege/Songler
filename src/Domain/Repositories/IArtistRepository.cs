using Domain.Entities;

namespace Domain.Repositories;

public interface IArtistRepository
{
    Task<List<Artist>> GetAllAsync();
    Task<Artist> GetByIdAsync(int id);
    Task<Artist> AddAsync(Artist artist);
    Task<bool> UpdateAsync(int id, Artist artist);
    Task<bool> DeleteAsync(int id);
}
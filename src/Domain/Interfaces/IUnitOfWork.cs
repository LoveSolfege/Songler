using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRepository<Artist> Artists { get; }
    IRepository<Album> Albums { get; }
    IRepository<Song> Songs { get; }
    IRepository<Grade> Grades { get; }
    
    public Task<int> SaveChangesAsync(CancellationToken ct = default);
}
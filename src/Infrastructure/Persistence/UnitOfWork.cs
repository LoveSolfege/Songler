using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly SongDbContext _context;
    public IRepository<Artist> Artists { get; }
    public IRepository<Album> Albums { get; }
    public IRepository<Song> Songs { get; }
    public IRepository<User> Users { get; }
    

    public UnitOfWork(
        SongDbContext context,
        IRepository<Artist> artists,
        IRepository<Album> albums,
        IRepository<Song> songs,
        IRepository<User> users)
    {
        _context = context;
        Artists = artists;
        Albums = albums;
        Songs = songs;
        Users = users;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return _context.SaveChangesAsync(ct);
    }
}
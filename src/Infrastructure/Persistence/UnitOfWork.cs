using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    public IRepository<Artist> Artists { get; }
    public IRepository<Album> Albums { get; }
    public IRepository<Song> Songs { get; }
    public IRepository<Grade> Grades { get; }

    public UnitOfWork(
        DbContext context,
        ArtistRepository artists,
        AlbumRepository albums,
        SongRepository songs,
        GradeRepository grades)
    {
        _context = context;
        Artists = artists;
        Albums = albums;
        Songs = songs;
        Grades = grades;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return _context.SaveChangesAsync(ct);
    }
}
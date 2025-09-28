using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class SongDbContext : DbContext
{
    public SongDbContext(DbContextOptions<SongDbContext> options) : base(options) { }
    
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Album> Albums => Set<Album>();
    public DbSet<Song> Songs => Set<Song>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.HasPostgresEnum<Role>();

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
    }
}
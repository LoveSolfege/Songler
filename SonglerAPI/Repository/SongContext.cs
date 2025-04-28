using Microsoft.EntityFrameworkCore;
using SonglerAPI.Entities;

namespace SonglerAPI.Repository;

public class SongContext(DbContextOptions<SongContext> options) : DbContext(options)
{
	public DbSet<Artist> Artists { get; set; }
	public DbSet<Song> Songs { get; set; }
	public DbSet<Album> Albums { get; set; }
	public DbSet<Grade> Grades { get; set; }
}
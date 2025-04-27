using Microsoft.EntityFrameworkCore;
using SonglerAPI.Entities;

namespace SonglerAPI.Repository;

public class SongContext(DbContextOptions<SongContext> options) : DbContext(options)
{
	public DbSet<Artist> Artists { get; set; }
}
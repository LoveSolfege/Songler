namespace SonglerAPI.Entities;

public class Artist
{
	public int ArtistId { get; set; }
	public required string Name { get; set; }
	public ICollection<Album> Albums { get; set; } = null!;
	public bool IsDeleted { get; set; } = false;
}
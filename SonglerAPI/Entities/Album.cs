namespace SonglerAPI.Entities;

public class Album
{

	public int AlbumId { get; set; }
	public required string Title { get; set; }
	public ICollection<Song> Songs { get; set; } = null!;
	public bool IsDeleted { get; set; } = false;
}
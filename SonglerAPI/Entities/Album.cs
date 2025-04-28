using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonglerAPI.Entities;

public class Album
{
	[Key]
	public int AlbumId { get; set; }
	
	[Required]
	[MaxLength(250)]
	public string Title { get; set; }
	
	[ForeignKey("ArtistId")]
	public int ArtistId { get; set; }
	
	[Required]
	public Artist Artist { get; set; }
	
	
	public ICollection<Song> Songs { get; set; } = null!;
	public bool IsDeleted { get; set; } = false;
}
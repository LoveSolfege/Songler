using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonglerAPI.Entities;

public class Song
{
	[Key]
	public int SongId { get; set; }
	
	[Required]
	[MaxLength(250)]
	public string Title { get; set; }
	
	[ForeignKey("AlbumId")]
	public int AlbumId { get; set; }
	
	[Required]
	public Album Album { get; set; }
	
	[ForeignKey("GradeId")]
	public int? GradeId { get; set; }
	public bool IsDeleted { get; set; } = false;
}
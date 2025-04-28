using System.ComponentModel.DataAnnotations;

namespace SonglerAPI.DTO.Create;

public class SongCreateDto
{
	[Required(ErrorMessage = "Title is required.")]
	[MaxLength(250, ErrorMessage = "Title cannot exceed 250 characters.")]
	public string Title { get; set; }
	
	[Required(ErrorMessage = "Album ID is required.")]
	public int AlbumId { get; set; }
	
	public int? GradeId { get; set; }
	
}
using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Create;

public class SongCreateDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(250, ErrorMessage = "Title cannot exceed 250 characters.")]
    public string Title { get; set; } = null!;
	
    [Required(ErrorMessage = "Album ID is required.")]
    public int AlbumId { get; set; }
	
    [Required(ErrorMessage = "Artist ID is required.")]
    public int ArtistId { get; set; }
    
    public int? GradeId { get; set; }
}
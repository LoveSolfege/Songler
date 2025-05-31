using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Create;

public class AlbumCreateDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(250, ErrorMessage = "Title cannot exceed 250 characters.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Artist ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Artist ID must be a positive integer.")]
    public int ArtistId { get; set; } 
    
    public ICollection<SongCreateDto>? Songs { get; set; }
}
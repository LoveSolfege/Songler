using System.ComponentModel.DataAnnotations;

namespace SonglerAPI.DTO.Create;

public class ArtistCreateDto
{
	[Required(ErrorMessage = "Name is required")]
	[MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters.")]
	public string Name { get; set; } = null!;
	
	public ICollection<AlbumCreateDto>? Albums { get; set; }
}
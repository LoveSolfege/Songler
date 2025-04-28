namespace SonglerAPI.DTO.Response;

public class ArtistResponseDto
{
	public int ArtistId { get; set; }
	public string Name { get; set; }
	public ICollection<AlbumResponseDto> Albums { get; set; }
}
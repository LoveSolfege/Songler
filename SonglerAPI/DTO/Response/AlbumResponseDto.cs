namespace SonglerAPI.DTO.Response;

public class AlbumResponseDto
{
	public int AlbumId { get; set; }
	public string Title { get; set; }
	public int ArtistId { get; set; }
	public string ArtistName { get; set; }
	public List<SongResponseDto> Songs { get; set; }
}
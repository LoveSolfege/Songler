namespace Application.DTO.Response;

public class AlbumResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public string ArtistName { get; set; }
    public List<SongResponseDto> Songs { get; set; }
}
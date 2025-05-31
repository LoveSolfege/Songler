namespace Application.DTO.Response;

public class ArtistResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<AlbumResponseDto> Albums { get; set; }
}
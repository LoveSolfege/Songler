namespace Application.DTO.Response;

public class SongResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AlbumId { get; set; }
    public string AlbumTitle { get; set; }
    public int ArtistId { get; set; }
    public string ArtistName { get; set; }
    public string? GradeLetter { get; set; }
    public int? GradeId { get; set; }
}
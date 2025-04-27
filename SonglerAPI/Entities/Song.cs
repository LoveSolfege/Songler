namespace SonglerAPI.Entities;

public class Song
{
	public int SongId { get; set; }
	public required string Title { get; set; }
	public int? GradeId { get; set; }
	public bool IsDeleted { get; set; } = false;
}
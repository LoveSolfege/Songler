namespace SonglerAPI.Entities;

public class Grade
{
	public int GradeId { get; set; }
	public required string Letter { get; set; }
	public bool IsDeleted { get; set; } = false;
}
using System.ComponentModel.DataAnnotations;

namespace SonglerAPI.Entities;

public class Grade : IEntity
{
	[Key]
	public int Id { get; set; }
	[Required]
	[MaxLength(10)]
	public string Letter { get; set; }
	public bool IsDeleted { get; set; } = false;
}
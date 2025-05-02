using System.ComponentModel.DataAnnotations;

namespace SonglerAPI.Entities;

public class Artist : IEntity
{
	[Key]
	public int Id { get; set; }
	
	[Required]
	[MaxLength(250)]
	public string Name { get; set; }
	public ICollection<Album> Albums { get; set; } = null!;
	public bool IsDeleted { get; set; } = false;
}
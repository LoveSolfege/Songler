using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Album
{
    [Key]
    public int Id { get; set; }
	
    [Required]
    [MaxLength(250)]
    public string Title { get; set; }
	
    [ForeignKey("Artist")]
    public int ArtistId { get; set; }
	
    [Required]
    public Artist Artist { get; set; }
	
	
    public ICollection<Song> Songs { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
}
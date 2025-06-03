using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Album : BaseEntity
{

    [Required] [MaxLength(250)] 
    public string Title { get; set; } = null!;
    
    [ForeignKey("Artist")]
    public int ArtistId { get; set; }

    [Required] 
    public Artist? Artist { get; set; } = null!;
	
    public ICollection<Song>? Songs { get; set; }
}
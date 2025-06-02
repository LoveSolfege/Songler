using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Song : BaseEntity
{
    [Required]
    [MaxLength(250)]
    public string Title { get; set; } = null!;
    public int Id { get; set; }
	
    [ForeignKey("Artist")]
    public int ArtistId { get; set; }
    
    [Required]
    public Artist Artist { get; set; } = null!;
    
    [ForeignKey("Album")]
    public int AlbumId { get; set; }
	
    [Required]
    public Album Album { get; set; } = null!;
	
    [ForeignKey("Grade")]
    public int? GradeId { get; set; }
    
    public Grade? Grade { get; set; }
    public bool IsDeleted { get; set; } = false;
}
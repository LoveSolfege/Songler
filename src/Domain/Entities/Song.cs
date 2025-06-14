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
    
    [ForeignKey("Album")]
    public int AlbumId { get; set; }
	
    [ForeignKey("Grade")]
    public int? GradeId { get; set; }
}
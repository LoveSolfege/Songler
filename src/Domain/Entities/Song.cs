using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Song
{
    [Key]
    public int Id { get; set; }
	
    [Required]
    [MaxLength(250)]
    public string Title { get; set; }
	
    [ForeignKey("Album")]
    public int AlbumId { get; set; }
	
    [Required]
    public Album Album { get; set; }
	
    [ForeignKey("Grade")]
    public int? GradeId { get; set; }
    public Grade Grade { get; set; }
    public bool IsDeleted { get; set; } = false;
}
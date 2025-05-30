using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Artist
{
    [Key]
    public int Id { get; set; }
    
    [Required] [MaxLength(250)] 
    public string Name { get; set; } = null!;
    
    public ICollection<Album> Albums { get; set; } = null!;
    public bool IsDeleted { get; set; } = false;
}
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Artist : BaseEntity
{
    [Required] [MaxLength(250)] 
    public string Name { get; set; } = null!;
}
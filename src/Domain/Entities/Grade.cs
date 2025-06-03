using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Grade : BaseEntity
{
    [Required]
    [MaxLength(10)]
    public string Letter { get; set; } = null!;
}
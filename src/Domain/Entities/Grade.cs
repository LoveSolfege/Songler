using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Grade
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(10)]
    public string Letter { get; set; }
    public bool IsDeleted { get; set; } = false;
}
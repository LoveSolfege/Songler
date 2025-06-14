using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class BaseEntity
{
    [Key] 
    public string Id { get; set; } = null!;
    public bool IsDeleted { get; set; }
}
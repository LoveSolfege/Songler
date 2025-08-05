namespace Domain.Entities;

public interface IDeletable
{
    public bool IsDeleted { get; set; }
}
namespace Domain.Entities;

public class UserData : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    
    public Guid UserDataHistoryId { get; set; }
    public UserDataHistory? UserDataHistory { get; set; }

    public ICollection<User> Users { get; set; } = [];
}
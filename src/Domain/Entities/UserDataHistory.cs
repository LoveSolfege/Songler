namespace Domain.Entities;

public class UserDataHistory : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string UserSurname { get; set; } = null!;
    public string UserUsername { get; set; } = null!;
    public string UserEmail { get; set; } = null!;
    public string UserPasswordHash { get; set; } = null!;
    public DateTime TimeChanged { get; set; } = DateTime.UtcNow;
    public UserData UserData { get; set; } = null!;
}
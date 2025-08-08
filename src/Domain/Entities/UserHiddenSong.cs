namespace Domain.Entities;

public class UserHiddenSong 
{
    
    public DateTime DateHidden { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
    public Guid SongId { get; set; }

    public User User { get; set; } = null!;
    public Song Song { get; set; } = null!;
}
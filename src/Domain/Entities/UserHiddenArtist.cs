namespace Domain.Entities;

public class UserHiddenArtist
{
    public DateTime DateHidden { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
    public Guid ArtistId { get; set; }

    public User User { get; set; } = null!;
    public Artist Artist { get; set; } = null!;
}
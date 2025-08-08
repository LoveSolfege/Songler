namespace Domain.Entities;

public class UserHiddenAlbum
{
    public DateTime DateHidden { get; set; } = DateTime.UtcNow;

    public Guid UserId { get; set; }
    public Guid AlbumId { get; set; }

    public User User { get; set; } = null!;
    public Album Album { get; set; } = null!;
}
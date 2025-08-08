namespace Domain.Entities;

public class UserRatedSong
{
    public int? Rating { get; set; }
    public DateTime RatedOn { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
    public Guid SongId { get; set; }

    public User User { get; set; } = null!;
    public Song Song { get; set; } = null!;
}
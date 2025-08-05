namespace Domain.Entities;

public class Song : IEntity, IDeletable
{
    public Guid Id { get; set; }
    public string SongTitle { get; set; } = null!;
    public DateTime TimeAdded { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }

    public ICollection<UserHiddenSong> UserHiddenSongs { get; set; } = [];
    public ICollection<UserRatedSongs> UserRatedSongs { get; set; } = [];
    public Guid AlbumId { get; set; }
    public Album Album { get; set; } = null!;
}
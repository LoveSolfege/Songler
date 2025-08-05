namespace Domain.Entities;

public class Album : IEntity, IDeletable
{
    public Guid Id { get; set; }
    public string AlbumTitle { get; set; } = null!;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    
    public bool IsDeleted { get; set; }
    
    public ICollection<Song> Songs { get; set; } = [];
    public ICollection<UserHiddenAlbum> UserHiddenAlbums { get; set; } = [];
    public Guid ArtistId { get; set; }
    public Artist Artist { get; set; } = null!;
}
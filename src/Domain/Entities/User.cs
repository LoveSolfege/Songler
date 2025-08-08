using System.Collections;

namespace Domain.Entities;

public class User : IEntity, IDeletable
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public Role Role { get; set; }
    public bool IsDeleted { get; set; }
    
    public Guid UserDataId { get; set; }
    public UserData UserData { get; set; } = null!;
    
    public ICollection<UserHiddenArtist> HiddenArtists { get; set; } = [];
    public ICollection<UserHiddenAlbum> HiddenAlbums { get; set; } = [];
    public ICollection<UserHiddenSong> HiddenSongs { get; set; } = [];
    public ICollection<UserRatedSong> RatedSongs { get; set; } = [];
}

public enum Role
{
    User,
    Admin,
}
namespace Domain.Entities;

public class Artist : IEntity, IDeletable
{
    public Guid Id { get; set; }
    public string ArtistName { get; set; } = null!;
    public DateTime TimeAdded { get; set; } = DateTime.UtcNow;
    public bool IsDeleted { get; set; }
    public ICollection<Album> Albums { get; set; } = [];
    public ICollection<UserHiddenArtist> UserHiddenArtists { get; set; } = [];
}
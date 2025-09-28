using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.DTO;

public class ArtistCreateDto
{
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters.")]
    public string Name { get; set; } = null!;
}

public class ArtistResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int SongCount { get; set; }
    public int AlbumCount { get; set; }
}

public static class ArtistMapping
{
    public static ArtistResponseDto ToDto(this Artist entity)
    {
        return new ArtistResponseDto
        {
            Id = entity.Id,
            Name = entity.ArtistName
        };
    }
    
    public static Artist ToEntity(this ArtistCreateDto dto)
    {
        return new Artist
        {
            ArtistName = dto.Name,
        };
    }
}
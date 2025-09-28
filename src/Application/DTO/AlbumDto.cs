using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.DTO;

public class AlbumCreateDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(250, ErrorMessage = "Title cannot exceed 250 characters.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Artist ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Artist ID must be a positive integer.")]
    public Guid ArtistId { get; set; } 
}

public class AlbumResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid ArtistId { get; set; }
    public string ArtistName { get; set; }
    public int SongCount { get; set; }
}

public static class AlbumMapping
{
    public static AlbumResponseDto ToDto(this Album entity)
    {
        return new AlbumResponseDto
        {
            Id = entity.Id,
            Title = entity.AlbumTitle,
            ArtistId = entity.ArtistId,
        };
    }

    public static Album ToEntity(this AlbumCreateDto dto)
    {
        return new Album
        {
            AlbumTitle = dto.Title,
            ArtistId = dto.ArtistId,
        };
    }
}
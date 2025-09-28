using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Application.DTO;

public class SongCreateDto
{
    [Required(ErrorMessage = "Title is required.")]
    [MaxLength(250, ErrorMessage = "Title cannot exceed 250 characters.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "Album ID is required.")]
    public Guid AlbumId { get; set; }
	
}

public class SongResponseDto
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public Guid AlbumId { get; set; }
	public string AlbumTitle { get; set; }
	public Guid ArtistId { get; set; }
	public string ArtistName { get; set; }
}

public static class SongMapping
{
	public static SongResponseDto ToDto(this Song entity)
	{
		return new SongResponseDto
		{
			Id = entity.Id,
			Title = entity.SongTitle,
			ArtistId = entity.AlbumId,
			AlbumId = entity.AlbumId,
			ArtistName = entity.Album.Artist.ArtistName,
			AlbumTitle = entity.Album.AlbumTitle,
		};
	}

	public static Song ToEntity(this SongCreateDto dto)
	{
		return new Song
		{
			SongTitle = dto.Title,
			AlbumId = dto.AlbumId,
		};
	}
}
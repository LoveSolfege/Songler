using Application.DTO.Create;
using Application.DTO.Response;
using MediatR;

namespace Application.Commands.Create;

public class CreateSongCommand : IRequest<SongResponseDto>
{
    public int ArtistId { get; set; }
    public int AlbumId { get; set; }
    public SongCreateDto Song { get; set; }

    public CreateSongCommand(int artistId, int albumId, SongCreateDto dto)
    {
        ArtistId = artistId;
        AlbumId = albumId;
        Song = dto;
    }
}
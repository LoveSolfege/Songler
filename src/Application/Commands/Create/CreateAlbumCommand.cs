using Application.DTO.Create;
using Application.DTO.Response;
using MediatR;

namespace Application.Commands.Create;

public class CreateAlbumCommand : IRequest<AlbumResponseDto>
{
    public int ArtistId { get; set; }
    public AlbumCreateDto Album { get; set; }

    public CreateAlbumCommand(int artistId, AlbumCreateDto dto)
    {
        ArtistId = artistId;
        Album = dto;
    }
}
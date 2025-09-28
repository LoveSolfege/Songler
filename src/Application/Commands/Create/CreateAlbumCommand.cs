using Application.DTO;
using MediatR;

namespace Application.Commands.Create;

public class CreateAlbumCommand : IRequest<AlbumResponseDto>
{
    public AlbumCreateDto Album { get; set; }

    public CreateAlbumCommand(AlbumCreateDto dto)
    {
        Album = dto;
    }
}
using Application.DTO.Create;
using Application.DTO.Response;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Create;

public class CreateArtistCommand : IRequest<ArtistResponseDto>
{
    public ArtistCreateDto Artist { get; set; }

    public CreateArtistCommand(ArtistCreateDto dto)
    {
        Artist = dto;
    }
}
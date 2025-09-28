using Application.DTO;
using MediatR;

namespace Application.Commands.Create;

public class CreateSongCommand : IRequest<SongResponseDto>
{
    public SongCreateDto Song { get; set; }

    public CreateSongCommand(SongCreateDto dto)
    {
        Song = dto;
    }
}
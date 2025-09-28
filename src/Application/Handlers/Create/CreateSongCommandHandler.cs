using Application.Commands.Create;
using Application.DTO;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Create;

public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, SongResponseDto>
{
    private readonly IUnitOfWork _uow;

    public CreateSongCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<SongResponseDto> Handle(CreateSongCommand request, CancellationToken ct = default)
    {
        var song = request.Song.ToEntity();
        await _uow.Songs.AddAsync(song);
        await _uow.SaveChangesAsync(ct);
        
        return song.ToDto();
    }
}
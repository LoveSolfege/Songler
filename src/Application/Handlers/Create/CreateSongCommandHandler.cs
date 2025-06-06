using Application.Commands.Create;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Create;

public class CreateSongCommandHandler : IRequestHandler<CreateSongCommand, SongResponseDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateSongCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<SongResponseDto> Handle(CreateSongCommand request, CancellationToken ct = default)
    {
        var song = _mapper.Map<Song>(request.Song);
        song.ArtistId = request.ArtistId;
        song.AlbumId = request.AlbumId;
        await _uow.Songs.AddAsync(song);
        await _uow.SaveChangesAsync(ct);
        
        return _mapper.Map<SongResponseDto>(song);
    }
}
using Application.Commands.Create;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Create;

public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, AlbumResponseDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateAlbumCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<AlbumResponseDto> Handle(CreateAlbumCommand request, CancellationToken ct = default)
    {
        var album = _mapper.Map<Album>(request.Album);
        album.ArtistId = request.ArtistId;
        await _uow.Albums.AddAsync(album);
        await _uow.SaveChangesAsync(ct);
        
        return _mapper.Map<AlbumResponseDto>(album);
    }
}
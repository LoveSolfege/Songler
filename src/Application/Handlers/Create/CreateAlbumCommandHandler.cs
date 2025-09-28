using Application.Commands.Create;
using Application.DTO;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Create;

public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, AlbumResponseDto>
{
    private readonly IUnitOfWork _uow;

    public CreateAlbumCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<AlbumResponseDto> Handle(CreateAlbumCommand request, CancellationToken ct = default)
    {
        var album = request.Album.ToEntity();
        await _uow.Albums.AddAsync(album);
        await _uow.SaveChangesAsync(ct);
        
        return album.ToDto();
    }
}
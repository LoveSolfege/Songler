using Application.Commands.Create;
using Application.DTO;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Create;

public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, ArtistResponseDto>
{
    private readonly IUnitOfWork _uow;

    public CreateArtistCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<ArtistResponseDto> Handle(CreateArtistCommand request, CancellationToken ct = default)
    {
        var artist = request.Artist.ToEntity();
        await _uow.Artists.AddAsync(artist);
        await _uow.SaveChangesAsync(ct);
        
        return artist.ToDto();
    }
}
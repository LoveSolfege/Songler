using Application.Commands.Create;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Create;

public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, ArtistResponseDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateArtistCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<ArtistResponseDto> Handle(CreateArtistCommand request, CancellationToken ct = default)
    {
        var artist = _mapper.Map<Artist>(request.Artist);
        await _uow.Artists.AddAsync(artist);
        await _uow.SaveChangesAsync(ct);
        
        return _mapper.Map<ArtistResponseDto>(artist);
    }
}
using Application.Commands.Create;
using Application.DTO.Response;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Handlers.Create;

public class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, GradeResponseDto>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateGradeCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<GradeResponseDto> Handle(CreateGradeCommand command, CancellationToken ct = default)
    {
        var grade = _mapper.Map<Grade>(command.Grade);
        await _uow.Grades.AddAsync(grade);
        await _uow.SaveChangesAsync(ct);
        
        return _mapper.Map<GradeResponseDto>(grade);
    }

}
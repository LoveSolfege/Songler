using Application.DTO.Create;
using Application.DTO.Response;
using MediatR;

namespace Application.Commands.Create;

public class CreateGradeCommand : IRequest<GradeResponseDto>
{
    public GradeCreateDto Grade { get; set; }

    public CreateGradeCommand(GradeCreateDto grade)
    {
        Grade = grade;
    }
}
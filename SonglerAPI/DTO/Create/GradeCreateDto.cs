using System.ComponentModel.DataAnnotations;

namespace SonglerAPI.DTO.Create;

public class GradeCreateDto
{

	[Required(ErrorMessage = "Letter is required.")]
	[MaxLength(10, ErrorMessage = "Letter cannot exceed 10 characters.")]
	public string Letter { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;

namespace Application.DTO;

public class UserCreateDto
{
    [Required(ErrorMessage = "Username is required.")]
    [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
    public string Username { get; set; } = null!;
    
    [Required(ErrorMessage = "Email is required.")]
    [MaxLength(254, ErrorMessage = "Email cannot exceed 254 characters.")]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Password is required.")]
    public string PasswordHash { get; set; } = null!;
}
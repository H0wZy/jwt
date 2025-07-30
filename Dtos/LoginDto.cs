using System.ComponentModel.DataAnnotations;

namespace jwt.Dtos;

public record LoginDto
{
    [Required(ErrorMessage = "Username ou E-mail é obrigatório.")]
    public string UsernameOrEmail { get; init; } = string.Empty;

    [Required(ErrorMessage = "Senha é obrigatória.")]
    public string Password { get; init; } = string.Empty;
}
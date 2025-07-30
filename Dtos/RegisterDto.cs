using System.ComponentModel.DataAnnotations;
using jwt.Enum;

namespace jwt.Dtos;

public record RegisterDto : IValidatableObject
{
    [Required(ErrorMessage = "Nome é obrigatório.")]
    public string Firstname { get; init; } = string.Empty;

    [Required(ErrorMessage = "Sobrenome é obrigatório.")]
    public string Lastname { get; init; } = string.Empty;

    [Required(ErrorMessage = "Nome de usuário é obrigatório.")]
    public string Username { get; init; } = string.Empty;

    [Required(ErrorMessage = "E-mail é obrigatório."), EmailAddress(ErrorMessage = "E-mail inválido.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "Cargo é obrigatório.")]
    public Cargo Cargo { get; init; }

    [Required(ErrorMessage = "Senha é obrigatório.")]
    public string Password { get; init; } = string.Empty;

    [Required(ErrorMessage = "Confirmação de senha é obrigatório.")]
    // ReSharper disable once MemberCanBePrivate.Global
    public string ConfirmPassword { get; init; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Password != ConfirmPassword)
        {
            yield return new ValidationResult("Senhas não coincidem.", [nameof(Password)]);
        }
    }
}
using jwt.Enum;

namespace jwt.Dtos;

public record LoginResponseDto(
    string Token,
    string Username,
    string Email,
    string Firstname,
    string Lastname,
    Cargo Cargo);
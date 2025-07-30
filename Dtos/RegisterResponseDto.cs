using jwt.Enum;

namespace jwt.Dtos;

public record RegisterResponseDto(
    int Id,
    string Username,
    string Email,
    string Firstname,
    string Lastname,
    Cargo Cargo);
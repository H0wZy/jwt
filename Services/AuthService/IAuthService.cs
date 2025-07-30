using jwt.Dtos;
using jwt.Models;

namespace jwt.Services.AuthService;

public interface IAuthService
{
    public Task<ResponseModel<RegisterResponseDto>> RegisterAsync(RegisterDto dto);
    public Task<ResponseModel<LoginResponseDto>> LoginAsync(LoginDto dto);
}
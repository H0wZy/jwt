using jwt.Dtos;
using jwt.Models;
using jwt.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace jwt.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<ResponseModel<RegisterResponseDto>>> RegisterAsync(RegisterDto dto)
    {
        var response = await authService.RegisterAsync(dto);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<ResponseModel<LoginResponseDto>>> LoginAsync(LoginDto dto)
    {
        var response = await authService.LoginAsync(dto);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}
using System.Security.Claims;
using jwt.Dtos;
using jwt.Models;
using jwt.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = User.FindFirstValue(ClaimTypes.Name);
        var email = User.FindFirstValue(ClaimTypes.Email);
        var firstname = User.FindFirstValue(ClaimTypes.GivenName);
        var lastname = User.FindFirstValue(ClaimTypes.Surname);
        var role = User.FindFirstValue(ClaimTypes.Role);

        var userInfo = new
        {
            Id = userId,
            Username = username,
            Email = email,
            Firstname = firstname,
            Lastname = lastname,
            Role = role
        };

        return Ok(new ResponseModel<object>(userInfo, "Perfil recuperado com sucesso!", true));
    }
}
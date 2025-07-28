using jwt.Dtos;
using jwt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jwt.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterUserDto dto)
    {
        return Ok();
    }
}
using jwt.Data;
using jwt.Dtos;
using jwt.Models;
using Microsoft.EntityFrameworkCore;

namespace jwt.Repositories.AuthRepository;

public class AuthRepository(AppDbContext context) : IAuthRepository
{
    public async Task<UserModel?> GetByEmailAsync(RegisterUserDto dto)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
    }
}
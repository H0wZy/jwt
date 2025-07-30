using jwt.Data;
using jwt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace jwt.Repositories.AuthRepository;

public class AuthRepository(AppDbContext context) : IAuthRepository
{
    public async Task<UserModel?> GetByEmailAsync(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<UserModel?> GetByUsernameAsync(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<UserModel> CreateUserAsync(UserModel user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<UserModel> UpdateUserAsync(UserModel user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return user;
    }
}
using jwt.Models;

namespace jwt.Repositories.AuthRepository;

public interface IAuthRepository
{
    public Task<UserModel?> GetByEmailAsync(string email);
    public Task<UserModel?> GetByUsernameAsync(string username);
    public Task<UserModel> CreateUserAsync(UserModel user);
    public Task<UserModel> UpdateUserAsync(UserModel user);
}
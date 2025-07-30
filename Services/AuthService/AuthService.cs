using jwt.Dtos;
using jwt.Models;
using jwt.Repositories.AuthRepository;
using jwt.Utils;

namespace jwt.Services.AuthService;

public class AuthService(IAuthRepository authRepository, IConfiguration configuration) : IAuthService
{
    public async Task<ResponseModel<RegisterResponseDto>> RegisterAsync(RegisterDto dto)
    {
        try
        {
            var existingEmail = await authRepository.GetByEmailAsync(dto.Email);
            var existingUsername = await authRepository.GetByUsernameAsync(dto.Username);

            if (existingEmail is not null)
            {
                return new ResponseModel<RegisterResponseDto>(null, "Este e-mail já existe.", false);
            }

            if (existingUsername is not null)
            {
                return new ResponseModel<RegisterResponseDto>(null, "Este nome de usuário já existe.", false);
            }

            var (hashPassword, saltPassword) = PasswordHelper.HashPassword(dto.Password);

            var user = new UserModel
            {
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Username = dto.Username,
                Email = dto.Email,
                Cargo = dto.Cargo,
                HashPassword = hashPassword,
                SaltPassword = saltPassword,
            };

            var savedUser = await authRepository.CreateUserAsync(user);

            return new ResponseModel<RegisterResponseDto>(
                new RegisterResponseDto(savedUser.Id, savedUser.Username, savedUser.Email, savedUser.Firstname,
                    savedUser.Lastname, savedUser.Cargo),
                "Usuário cadastrado com sucesso!", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new ResponseModel<RegisterResponseDto>(null, "Erro interno no servidor.", false);
        }
    }

    public async Task<ResponseModel<LoginResponseDto>> LoginAsync(LoginDto dto)
    {
        try
        {
            var user = await authRepository.GetByEmailAsync(dto.UsernameOrEmail) ??
                       await authRepository.GetByUsernameAsync(dto.UsernameOrEmail);

            if (user is null)
            {
                return new ResponseModel<LoginResponseDto>(null, "Credenciais inválidas.", false);
            }

            var isPasswordValid = PasswordHelper.VerifyPassword(dto.Password, user.HashPassword, user.SaltPassword);

            if (!isPasswordValid)
            {
                return new ResponseModel<LoginResponseDto>(null, "Credenciais inválidas.", false);
            }

            user.LastLoginAt = DateTime.UtcNow;
            await authRepository.UpdateUserAsync(user);

            var token = JwtHelper.GenerateToken(user, configuration);

            return new ResponseModel<LoginResponseDto>(
                new LoginResponseDto(token, user.Username, user.Email, user.Firstname, user.Lastname, user.Cargo),
                "Login realizado com sucesso!",
                true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new ResponseModel<LoginResponseDto>(null, "Erro interno no servidor.", false);
        }
    }
}
using jwt.Dtos;
using jwt.Models;

namespace jwt.Services.AuthService;

public class AuthService : IAuthService
{
    public async Task<ResponseModel<RegisterUserDto>> Register(RegisterUserDto dto)
    {
        var response = new ResponseModel<RegisterUserDto>(null, "", false);
        
        try
        {
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return response;
        }

        return response;
    }
}
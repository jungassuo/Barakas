using Barakas.Services.AuthAPI.Models.DTO;

namespace Barakas.Services.AuthAPI.Services.IService
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDTO registration);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);
        Task<bool> AssignRole(string email, string roleName);
    }
}

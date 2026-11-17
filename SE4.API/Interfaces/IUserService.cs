using SE4.API.DTOs;

namespace SE4.API.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);

        Task<AuthResponseDto> LoginAsync(LoginDto dto);

        Task<AuthResponseDto> ChangePasswordAsync(ChangePasswordDto dto);
    }
}
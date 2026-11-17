using Microsoft.AspNetCore.Mvc;
using SE4.API.DTOs;
using SE4.API.Interfaces;

namespace SE4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register(
            [FromBody] RegisterDto dto)
        {
            var result = await _userService.RegisterAsync(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(
            [FromBody] LoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);
            return Ok(result);
        }

        [HttpPost("change-password")]
        public async Task<ActionResult<AuthResponseDto>> ChangePassword(
            [FromBody] ChangePasswordDto dto)
        {
            var result = await _userService.ChangePasswordAsync(dto);
            return Ok(result);
        }
    }
}

using Business.Dtos;
using Business.Dtos.User;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/register")]
        public async Task<IActionResult> RegisterAsync(UserDto userDto)
        {
            await _authService.RegisterAsync(userDto);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> LoginAsync(AuthDto authDto)
        {
            var tokenDto = await _authService.LoginAsync(authDto.Email, authDto.Password);

            if (tokenDto == null)
            {
                return Unauthorized();
            }

            return Ok(tokenDto);
        }
    }
}

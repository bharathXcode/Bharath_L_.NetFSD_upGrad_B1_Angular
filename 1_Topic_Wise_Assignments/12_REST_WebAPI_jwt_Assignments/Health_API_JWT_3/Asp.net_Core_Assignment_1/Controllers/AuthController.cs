using Asp.net_Core_Assignment_1.DTOs.Auth;
using Asp.net_Core_Assignment_1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Assignment_1.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            if (!_jwtTokenService.ValidationCredentials(dto.UserName, dto.Password))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
            var (token, expiresAt, role) = _jwtTokenService.GenrateToken(dto.UserName);
            return Ok(new LoginResponseDto
            {
                Token = token,
                ExpiresAt = expiresAt,
                Role = role
            });
        }
    }
}

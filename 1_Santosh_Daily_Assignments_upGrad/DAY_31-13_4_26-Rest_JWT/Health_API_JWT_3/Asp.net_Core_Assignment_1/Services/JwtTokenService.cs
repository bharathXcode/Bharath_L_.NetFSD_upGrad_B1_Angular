using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Asp.net_Core_Assignment_1.Services
{
    public class JwtTokenService:IJwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (string token, DateTime expiresAt, string role) GenrateToken(string username)
        {
            var key = _configuration["Jwt:Key"]!;
            var issuer = _configuration["Jwt:Issuer"]!;
            var audience = _configuration["Jwt:Audience"]!;
            var minuted = int.Parse(_configuration["Jwt:DurationInMinutes"] ?? "60");

            var expiresAt=DateTime.Now.AddMinutes(minuted);
            var role = "PrescriptionAdmin";

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role,role)
            };

            var sigingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(sigingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:issuer,
                audience:audience,
                claims:claims,
                expires:expiresAt,
                signingCredentials:creds
                );
            return (new JwtSecurityTokenHandler().WriteToken(token),expiresAt,role);
        }

        public bool ValidationCredentials(string username, string password)
        {
            var configureUser = _configuration["Jwt:Username"];
            var configurePassword = _configuration["Jwt:Password"];
            return username==configurePassword && password==configureUser;
        }
    }
}

namespace Asp.net_Core_Assignment_1.Services
{
    public interface IJwtTokenService
    {
        (string token, DateTime expiresAt, string role) GenrateToken(string username);
        bool ValidationCredentials(string username, string password);
    }
}

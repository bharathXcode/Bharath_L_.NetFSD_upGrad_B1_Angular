namespace Asp.net_Core_Assignment_1.DTOs.Auth
{
    public class LoginResponseDto
    {
        public string Token {  get; set; }=string.Empty;
        public DateTime ExpiresAt {  get; set; }
        public string Role {  get; set; }= string.Empty;
    }
}

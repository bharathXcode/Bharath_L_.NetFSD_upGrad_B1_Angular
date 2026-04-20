using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }=string.Empty;

        [Required]
        public string Password {  get; set; }=string.Empty;
    }
}

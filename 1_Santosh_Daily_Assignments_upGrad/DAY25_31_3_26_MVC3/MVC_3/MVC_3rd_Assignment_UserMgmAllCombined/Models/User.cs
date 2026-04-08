using System.ComponentModel.DataAnnotations;

namespace MVC_3rd_Assignment_UserMgmAllCombined.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Minimum 6 characters")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password do not Match")]
        public string ConfirmPassword { get; set; }
    }
}

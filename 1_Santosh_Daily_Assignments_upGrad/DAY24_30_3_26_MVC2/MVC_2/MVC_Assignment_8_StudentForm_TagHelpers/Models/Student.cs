using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment_8_StudentForm_TagHelpers.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50, ErrorMessage = "Name Cannot exceeds 50 charcters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Age")]
        [Range(18, 60, ErrorMessage = "Age must be bwtween 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment_6_StudentValidation_DataAnnotations.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(50, ErrorMessage = "Name cannot exceeds 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Age")]
        [Range(18, 60, ErrorMessage = "Age between 18 and 60")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment_9_StudentRegistrationPortal_MVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}

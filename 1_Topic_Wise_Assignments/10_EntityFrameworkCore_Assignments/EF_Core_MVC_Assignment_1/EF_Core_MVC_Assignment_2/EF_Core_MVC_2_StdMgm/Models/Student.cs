using System.ComponentModel.DataAnnotations;

namespace EFCore_Assignment_2.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
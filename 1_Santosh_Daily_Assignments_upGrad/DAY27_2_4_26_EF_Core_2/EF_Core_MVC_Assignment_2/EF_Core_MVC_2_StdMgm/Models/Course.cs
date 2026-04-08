using System.ComponentModel.DataAnnotations;

namespace EFCore_Assignment_2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int Credits { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
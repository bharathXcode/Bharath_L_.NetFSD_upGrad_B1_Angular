namespace MVC_Assignment_2_Student_ModelDesign.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public List<Course> Courses { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_2_Student_ModelDesign.Models;

namespace MVC_Assignment_2_Student_ModelDesign.Controllers
{
    public class StudentController : Controller
    {

        private static List<Student> students = new List<Student>()
{
    new Student
    {
        Id = 1,
        Name = "Bharath L",
        Age = 23,
        Email = "bharath@gmail.com",
        Courses = new List<Course>
        {
            new Course
            {
                CourseId = 101,
                CourseName = "C#",
                StudentId = 1
            },
            new Course
            {
                CourseId = 102,
                CourseName = "Asp.net",
                StudentId = 1
            }
        }
    },

    new Student
    {
        Id = 2,
        Name = "Kumar",
        Age = 21,
        Email = "Kumar@gmail.com",
        Courses = new List<Course>
        {
            new Course
            {
                CourseId = 102,
                CourseName = "Asp.net",
                StudentId = 2
            }
        }
    }
};
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }
            return View(student);
        }
    }
}

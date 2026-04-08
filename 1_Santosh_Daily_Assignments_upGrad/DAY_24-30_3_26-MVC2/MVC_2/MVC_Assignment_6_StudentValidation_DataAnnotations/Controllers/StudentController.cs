using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_6_StudentValidation_DataAnnotations.Models;

namespace MVC_Assignment_6_StudentValidation_DataAnnotations.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Bharath L",Age=23,Email="bharath@gmail.com"}
        };
        public IActionResult Index()
        {
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Max(s => s.Id) + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_7_StudentForm_HTMLHelpers.Models;

namespace MVC_Assignment_7_StudentForm_HTMLHelpers.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Pavan",Age=22,Email="pavan@gmail.com"}
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
                student.Id = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}

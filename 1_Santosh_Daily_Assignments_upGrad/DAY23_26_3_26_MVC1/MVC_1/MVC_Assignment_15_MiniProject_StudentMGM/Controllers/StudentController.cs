using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_15_MiniProject_StudentMGM.Models;
namespace MVC_Assignment_15_MiniProject_StudentMGM.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string name, int age)
        {
            // Create model
            Student student = new Student
            {
                Name = name,
                Age = age
            };

            // ViewData (extra info)
            ViewData["Message"] = "Student Details Page";

            return View(student);
        }
    }
}

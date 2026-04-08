using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_3_Student_RazorView.Models;

namespace MVC_Assignment_3_Student_RazorView.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student()
            {
                ID = 1,
                Name = "Bharath L",
                Age = 23,
                Email = "bharath@gmail.com"
            };
            return View(student);
        }


    }
}

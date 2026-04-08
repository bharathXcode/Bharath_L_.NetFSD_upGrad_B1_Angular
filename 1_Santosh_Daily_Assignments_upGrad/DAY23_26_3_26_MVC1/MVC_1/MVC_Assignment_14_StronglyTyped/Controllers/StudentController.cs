using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_14_StronglyTyped.Models;

namespace MVC_Assignment_14_StronglyTyped.Controllers

{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            Student s = new Student()
            {
                Name = "Bharath L",
                Age = 23
            };
            return View(s);
        }
    }
}

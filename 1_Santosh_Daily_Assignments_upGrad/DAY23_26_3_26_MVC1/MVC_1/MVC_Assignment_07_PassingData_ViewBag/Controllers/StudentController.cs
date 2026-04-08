using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment_07_PassingData_ViewBag.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            ViewBag.Name = "Bharath";
            ViewBag.Age = 23;
            return View();
        }

    }
}

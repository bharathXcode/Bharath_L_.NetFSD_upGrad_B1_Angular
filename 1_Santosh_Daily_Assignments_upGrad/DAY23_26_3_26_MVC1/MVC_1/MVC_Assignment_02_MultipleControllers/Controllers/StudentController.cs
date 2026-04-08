using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment_02_MultipleControllers.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return Content("Student Index Page");
        }
        public IActionResult Profile()
        {
            return Content("Student Profile Page");
        }
    }
}

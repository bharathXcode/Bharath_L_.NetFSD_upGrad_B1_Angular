using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment_1_Studnet_BasicControllers.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
        public IActionResult GetStudent(int id)
        {
            return Content($"Student Id: {id}");
        }

    }
}

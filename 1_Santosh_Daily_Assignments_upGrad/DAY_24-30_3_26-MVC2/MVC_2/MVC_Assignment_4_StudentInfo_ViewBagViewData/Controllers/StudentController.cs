using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment_4_StudentInfo_ViewBagViewData.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.StudentName = "Bharath L";
            ViewData["StudentAge"] = 23;
            return View();
        }
    }
}

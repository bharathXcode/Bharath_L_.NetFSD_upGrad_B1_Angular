using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment_05_MultipleParameters_Calculator.Controllers
{
    public class MathController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Add(int a, int b)
        {
            return Content($"Sum= {a + b}");
        }
        public IActionResult Multiply(int a, int b)
        {
            return Content($"Multiply= {a * b}");
        }

    }
}

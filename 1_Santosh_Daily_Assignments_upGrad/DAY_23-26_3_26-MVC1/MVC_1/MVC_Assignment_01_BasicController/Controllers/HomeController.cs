using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_01_BasicController.Models;
using System.Diagnostics;

namespace MVC_Assignment_01_BasicController.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // 3 own action methods added here.
        public IActionResult Index1()
        {
            return Content("Welcome to ASP.NET Core MVC");
        }

        public IActionResult About()
        {
            return Content("This is About Page");
        }

        public IActionResult Contact()
        {
            return Content("Contact us at support@test.com");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

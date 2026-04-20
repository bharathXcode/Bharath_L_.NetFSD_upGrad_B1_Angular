using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_08_ViewData.Models;
using System.Diagnostics;

namespace MVC_Assignment_08_ViewData.Controllers
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

        public IActionResult Details()
        {
            ViewData["Name"] = "John";
            ViewData["Age"] = 25;
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

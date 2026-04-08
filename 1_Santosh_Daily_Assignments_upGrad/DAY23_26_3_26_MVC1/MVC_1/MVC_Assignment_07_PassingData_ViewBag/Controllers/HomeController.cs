using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_07_PassingData_ViewBag.Models;
using System.Diagnostics;

namespace MVC_Assignment_07_PassingData_ViewBag.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

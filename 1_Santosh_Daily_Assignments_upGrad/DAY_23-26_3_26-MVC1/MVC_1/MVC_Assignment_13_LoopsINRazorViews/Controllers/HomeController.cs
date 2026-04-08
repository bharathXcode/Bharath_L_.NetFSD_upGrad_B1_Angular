using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_13_LoopsINRazorViews.Models;
using System.Diagnostics;

namespace MVC_Assignment_13_LoopsINRazorViews.Controllers
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

        public IActionResult Student()
        {
            List<string> students = new List<string>()
            {
                "Bharath","Kamli","kiran"
            };
            ViewBag.Students = students;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

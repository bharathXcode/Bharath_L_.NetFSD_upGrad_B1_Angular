using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_10_MultipleViewData_Employee.Models;
using System.Diagnostics;

namespace MVC_Assignment_10_MultipleViewData_Employee.Controllers
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
            ViewData["Name"] = "Bharath L";
            ViewData["Salary"] = 5000000;
            ViewData["Department"] = "Development & AI";
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

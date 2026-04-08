using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_5_StudentManagement_CRUD_EFCore.Models;
using System.Diagnostics;

namespace MVC_Assignment_5_StudentManagement_CRUD_EFCore.Controllers
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

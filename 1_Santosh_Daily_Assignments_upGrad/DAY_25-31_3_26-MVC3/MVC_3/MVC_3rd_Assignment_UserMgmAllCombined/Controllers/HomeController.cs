using Microsoft.AspNetCore.Mvc;
using MVC_3rd_Assignment_UserMgmAllCombined.Models;
using System.Diagnostics;

namespace MVC_3rd_Assignment_UserMgmAllCombined.Controllers
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

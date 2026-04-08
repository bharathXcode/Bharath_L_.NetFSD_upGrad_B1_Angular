using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment_03_UserDetails.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Details(String name, int age)
        {
            return Content($"Name: {name} Age: {age}");
        }
    }
}

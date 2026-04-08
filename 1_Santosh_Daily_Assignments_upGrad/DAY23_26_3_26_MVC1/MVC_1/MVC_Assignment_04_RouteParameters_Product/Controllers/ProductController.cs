using Microsoft.AspNetCore.Mvc;

namespace MVC_Assignment_04_RouteParameters_Product.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetProduct(int id)
        {
            return Content($"Product Id is: {id}");
        }
    }
}

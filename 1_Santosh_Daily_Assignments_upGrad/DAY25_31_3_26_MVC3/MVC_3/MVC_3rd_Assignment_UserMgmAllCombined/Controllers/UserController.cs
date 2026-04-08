using Microsoft.AspNetCore.Mvc;
using MVC_3rd_Assignment_UserMgmAllCombined.Models;
using MVC_3rd_Assignment_UserMgmAllCombined.ViewModel;

namespace MVC_3rd_Assignment_UserMgmAllCombined.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>();

        // ---------------- REGISTER ----------------
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = users.Count + 1;  //  Assign ID
                users.Add(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // ---------------- LOGIN ----------------
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserEmail", user.Email);
                return RedirectToAction("Profile");
            }

            ViewBag.Error = "Invalid Login";
            return View();
        }

        // ---------------- PROFILE ----------------
        public IActionResult Profile()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
            {
                return RedirectToAction("Login");
            }

            var user = users.FirstOrDefault(u => u.Email == email);

            //  NULL CHECK (IMPORTANT)
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var vm = new UserViewModel
            {
                Name = user.Name,
                Email = user.Email
            };

            return View(vm);
        }

        // ---------------- EDIT (GET) ----------------
        public IActionResult Edit()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
            {
                return RedirectToAction("Login");
            }

            var user = users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // ---------------- EDIT (POST) ----------------
        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
            {
                return RedirectToAction("Login");
            }

            var user = users.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                //  Update name
                user.Name = updatedUser.Name;

                //  Update password ONLY if provided
                if (!string.IsNullOrEmpty(updatedUser.Password))
                {
                    user.Password = updatedUser.Password;
                }
            }

            return RedirectToAction("Profile");
        }

        // ---------------- LOGOUT ----------------
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
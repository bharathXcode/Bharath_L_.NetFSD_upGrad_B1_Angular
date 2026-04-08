using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_9_StudentRegistrationPortal_MVC.Models;

namespace MVC_Assignment_9_StudentRegistrationPortal_MVC.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Bharath L",Age=23,Email="bharath@gmail.com"},
            new Student{Id=2,Name="Ravi",Age=23,Email="ravi@gmail.com"}
        };
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Success"];
            return View(students);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Student Registration";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Max(s => s.Id) + 1;
                students.Add(student);
                TempData["Success"] = "Student registered Successfully";
                return RedirectToAction("index");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var exisiting = students.FirstOrDefault(s => s.Id == student.Id);
            if (exisiting != null && ModelState.IsValid)
            {
                exisiting.Name = student.Name;
                exisiting.Age = student.Age;
                exisiting.Email = student.Email;

                TempData["Success"] = "Student Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                TempData["Success"] = "student Deleted Successfully";
            }
            return RedirectToAction("Index");
        }
    }
}

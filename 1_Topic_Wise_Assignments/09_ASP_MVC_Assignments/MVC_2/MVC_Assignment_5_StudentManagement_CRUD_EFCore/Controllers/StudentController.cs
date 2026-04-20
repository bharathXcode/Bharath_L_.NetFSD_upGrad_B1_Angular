using Microsoft.AspNetCore.Mvc;
using MVC_Assignment_5_StudentManagement_CRUD_EFCore.Models;
namespace MVC_Assignment_5_StudentManagement_CRUD_EFCore.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>()
        {
            new Student{Id=1,Name="Bharath L",Age=23,Email="bharath@gmail.com"},
            new Student{Id=2,Name="Ravi",Age=21,Email="ravi@gmail.com"}
        };
        public IActionResult Index()
        {
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int Id)
        {
            var student = students.FirstOrDefault(s => s.Id == Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.Age = updatedStudent.Age;
                student.Email = updatedStudent.Email;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            return View(student); // ✅ single object
        }

        [HttpPost]
        public IActionResult Delete(Student deleteStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == deleteStudent.Id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }
    }
}

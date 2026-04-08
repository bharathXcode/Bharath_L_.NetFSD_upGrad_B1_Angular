using EFCore_Assignment_2.Data;
using EFCore_Assignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Assignment_2.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }

        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
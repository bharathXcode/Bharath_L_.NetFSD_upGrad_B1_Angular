using Asp.net_Core_Assignment_1.Database;
using Asp.net_Core_Assignment_1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly HealthCareDBCOntext _context;

        public DoctorRepository(HealthCareDBCOntext context)
        {
            _context = context;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            _context.doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(Doctor doctor)
        {
            _context.doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _context.doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctor(string Specialization)
        {
            var doctor=await _context.doctors.FirstOrDefaultAsync(x=>x.Specialization==Specialization);
            return doctor;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _context.doctors.Include(d => d.Appointments).FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task<List<Doctor>> GetDoctorBySpecialization(string Specialization)
        {
            return await _context.doctors.AsNoTracking().Where(d=>d.Specialization.ToLower()==Specialization.ToLower()).ToListAsync();
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            _context.doctors.Remove(doctor);
            await _context.SaveChangesAsync();
        }

        
    }
}

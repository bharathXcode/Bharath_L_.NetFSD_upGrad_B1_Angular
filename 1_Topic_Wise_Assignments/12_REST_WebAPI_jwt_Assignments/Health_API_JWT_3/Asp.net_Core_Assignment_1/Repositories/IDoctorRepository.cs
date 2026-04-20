using Asp.net_Core_Assignment_1.Entities;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public interface IDoctorRepository
    {
        public Task<List<Doctor>> GetAllDoctors();
        public Task<Doctor> GetDoctor(int id);
        public Task<List<Doctor>> GetDoctorBySpecialization (string Specialization);
        public Task AddDoctor(Doctor doctor);
        public Task UpdateDoctor(Doctor doctor);
        public Task DeleteDoctor(Doctor doctor);
    }
}

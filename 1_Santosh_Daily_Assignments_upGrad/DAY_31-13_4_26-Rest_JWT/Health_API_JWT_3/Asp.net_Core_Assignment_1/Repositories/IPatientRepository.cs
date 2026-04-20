using Asp.net_Core_Assignment_1.Entities;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public interface IPatientRepository
    {
        public Task<List<Patient>> GetAllPatients();
        public Task<Patient> GetPatient(int id);
        public Task AddPatient(Patient patient);
        public Task UpdatePatient(Patient patient);
        public Task DeletePatient(Patient patient);
        public Task<Patient> Search(string name);
    }
}

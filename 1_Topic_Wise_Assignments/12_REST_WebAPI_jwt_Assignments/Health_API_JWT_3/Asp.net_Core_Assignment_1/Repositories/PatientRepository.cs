using Asp.net_Core_Assignment_1.Database;
using Asp.net_Core_Assignment_1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public class PatientRepository:IPatientRepository
    {
        private readonly HealthCareDBCOntext _context;

        public PatientRepository(HealthCareDBCOntext context)
        {
            _context = context;
        }

        public async Task AddPatient(Patient patient)
        {
            _context.patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePatient(Patient patient)
        {
            _context.patients.Remove(patient);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.patients.ToListAsync();
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient=await _context.patients.FindAsync(id);
            return patient;
        }

        public async Task<Patient> Search(string name)
        {
            var patient=await _context.patients.SingleOrDefaultAsync(x => x.Name==name);
            return patient;
        }

        public async Task UpdatePatient(Patient patient)
        {
            _context.patients.Update(patient);
            await _context.SaveChangesAsync();
        }
    }
}

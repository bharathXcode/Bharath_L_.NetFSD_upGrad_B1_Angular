using Asp.net_Core_Assignment_1.Database;
using Asp.net_Core_Assignment_1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public class PrescriptionRepository:IPrescriptionRepository
    {
        private readonly HealthCareDBCOntext _context;

        public PrescriptionRepository(HealthCareDBCOntext context)
        {
            _context = context;
        }

        public async Task AddPrescription(Prescription prescription)
        {
            _context.prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task<Prescription> GetPrescription(int id)
        {
            return await _context.prescriptions.AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrescriptionId == id);
        }

        public async Task<Prescription> GetPrescriptionByAppointmentId(int appointmentId)
        {
            return await _context.prescriptions.AsNoTracking()
                .FirstOrDefaultAsync(p => p.AppointmentId == appointmentId);
        }

    }
}

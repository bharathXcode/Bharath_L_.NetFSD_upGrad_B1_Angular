using Asp.net_Core_Assignment_1.Entities;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public interface IPrescriptionRepository
    {
        public Task<Prescription> GetPrescription(int id);
        public Task<Prescription> GetPrescriptionByAppointmentId(int appointmentId);
        public Task AddPrescription(Prescription prescription);
    }
}

using Asp.net_Core_Assignment_1.Entities;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public interface IAppointmentRepository
    {
        public Task<List<Appointment>> GetAllAppointments();
        public Task<Appointment> GetAppointment(int id);
        public Task<List<Appointment>> GetAppointmentByPatientId(int PatientId);
        public Task<List<Appointment>> GetAppointmentByDoctorId(int DoctorId);
        public Task AddAppointment(Appointment appointment);
        public Task UpdateAppointment(Appointment appointment);
    }
}

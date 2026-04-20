using Asp.net_Core_Assignment_1.Database;
using Asp.net_Core_Assignment_1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Assignment_1.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealthCareDBCOntext _context;

        public AppointmentRepository(HealthCareDBCOntext context)
        {
            _context = context;
        }

        public async Task AddAppointment(Appointment appointment)
        {
            _context.appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _context.appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            return await _context.appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.Prescription)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task<List<Appointment>> GetAppointmentByDoctorId(int DoctorId)
        {
            return await _context.appointments
                .AsNoTracking()
                .Where(a => a.DoctorId == DoctorId)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetAppointmentByPatientId(int PatientId)
        {
            return await _context.appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .AsNoTracking()
                .Where(a => a.PatientId == PatientId)
                .ToListAsync();
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            _context.appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}

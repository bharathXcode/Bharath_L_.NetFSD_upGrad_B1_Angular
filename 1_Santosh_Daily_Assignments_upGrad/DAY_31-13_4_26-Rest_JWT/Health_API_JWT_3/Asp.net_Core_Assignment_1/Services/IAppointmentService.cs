using Asp.net_Core_Assignment_1.DTOs.Appointments;

namespace Asp.net_Core_Assignment_1.Services
{
    public interface IAppointmentService
    {
        Task<List<AppointmentReadDto>> GetAllAsync();
        Task<List<AppointmentReadDto>> GetByPatientIdAsync(int  patientId);
        Task CreateAsync(AppointmentCreateDto dto);
        Task CancelAsync(int id);
    }
}

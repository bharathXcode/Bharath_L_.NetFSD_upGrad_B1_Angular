using Asp.net_Core_Assignment_1.DTOs.Prescriptions;

namespace Asp.net_Core_Assignment_1.Services
{
    public interface IPrescriptionService
    {
        Task<PrescriptionReadDto> GetByAppointmentIdAsync(int appointmentId);
        Task CreateAsync(PrescriptionCreateDto dto);
    }
}

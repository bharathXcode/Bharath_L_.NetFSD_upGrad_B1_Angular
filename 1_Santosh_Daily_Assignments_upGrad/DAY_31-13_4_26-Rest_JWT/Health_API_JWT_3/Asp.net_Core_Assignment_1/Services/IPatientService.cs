using Asp.net_Core_Assignment_1.DTOs.Patients;

namespace Asp.net_Core_Assignment_1.Services
{
    public interface IPatientService
    {
        Task<List<PatientReadDto>> GetAllAsync();
        Task<PatientReadDto> GetByIdAsync(int id);
        Task CreateAsync(PatientCreateDto dto);
        Task UpdateAsync(int id, PatientUpdateDto dto);
        Task DeleteAsync(int id);
    }
}

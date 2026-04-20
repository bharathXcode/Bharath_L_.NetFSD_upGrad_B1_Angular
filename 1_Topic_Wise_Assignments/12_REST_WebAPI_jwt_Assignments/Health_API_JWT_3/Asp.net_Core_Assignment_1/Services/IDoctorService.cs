using Asp.net_Core_Assignment_1.DTOs.Doctors;

namespace Asp.net_Core_Assignment_1.Services
{
    public interface IDoctorService
    {
        Task<List<DoctorReadDto>> GetAllAsync();
        Task<List<DoctorReadDto>> GetBySpecializationAsync(string specialization);
        Task CreateAsync(DoctorCreateDto dto);
        Task DeleteAsync(int id);
    }
}

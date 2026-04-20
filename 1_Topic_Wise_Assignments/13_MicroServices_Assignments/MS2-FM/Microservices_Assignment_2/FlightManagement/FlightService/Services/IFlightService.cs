using FlightService.DTOs;

namespace FlightService.Services
{
    public interface IFlightService
    {
        Task AddFlightAsync(CreateFlightDto dto);
        Task UpdateFlightAsync(int id,UpdateFlightDto dto);
        Task DeleteFlightAsync(int id);
        Task<List<ReadFlightDto>> GetAllFlightAsync();
        Task<ReadFlightDto> GetFlightByIdAsync(int id);
    }
}

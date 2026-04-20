using FlightService.Model;

namespace FlightService.Service
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetAllAsync();
        Task<Flight> GetByIdAsync(int id);
        Task CreateAsync(Flight flight);
        Task UpdateAsync(int id,Flight flight);
        Task DeleteAsync(int id);
    }
}

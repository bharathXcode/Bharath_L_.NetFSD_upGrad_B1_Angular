using PassengerService.DTOs;

namespace PassengerService.Services
{
    public interface IPassengerService
    {
        Task<List<ReadPassengerDto>> GetAllPassenger();
        Task CreatePassenger(CreatePassengerDto dto);
    }
}

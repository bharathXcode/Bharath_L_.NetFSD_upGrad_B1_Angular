using PassengerService.Model;

namespace PassengerService.Repositories
{
    public interface IPassengerRepository
    {
        Task<List<Passenger>> GetAll();
        Task Create(Passenger passenger);
    }
}

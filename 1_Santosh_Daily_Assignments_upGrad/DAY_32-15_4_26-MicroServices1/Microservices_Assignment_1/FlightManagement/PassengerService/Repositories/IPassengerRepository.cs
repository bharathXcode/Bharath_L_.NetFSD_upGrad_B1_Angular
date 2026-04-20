using PassengerService.Model;

namespace PassengerService.Repositories
{
    public interface IPassengerRepository
    {
        List<Passenger> GetAll();
        Passenger Create(Passenger passenger);
    }
}

using PassengerService.Model;

namespace PassengerService.Repositories
{
    public class PassengerRepository:IPassengerRepository
    {
        private static List<Passenger> passengers = new List<Passenger>
        {
            new Passenger{PassengerId=201,Name="John Doe",Age=30}
        };

        public Passenger Create(Passenger passenger)
        {
            passengers.Add(passenger);
            return passenger;
        }

        public List<Passenger> GetAll()
        {
            return passengers;
        }
    }
}

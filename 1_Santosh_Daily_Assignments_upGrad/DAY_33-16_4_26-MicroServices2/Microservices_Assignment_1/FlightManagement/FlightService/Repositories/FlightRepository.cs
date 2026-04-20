using FlightService.Model;

namespace FlightService.Service
{
    public class FlightRepository:IFlightRepository
    {
        private static List<Flight> flights= new List<Flight>
        {
            new Flight{Id=1,FlightNumber="AI101",Source="Hyderabad",Destination="Delhi"},
            new Flight{Id=2,FlightNumber="AI202",Source="Mumbai",Destination="Banglore"}
        };

        public Flight Create(Flight flight)
        {
            flights.Add(flight);
            return flight;
        }

        public List<Flight> GetAll()
        {
            return flights;
        }

        public Flight GetById(int id)
        {
            return flights.FirstOrDefault(f=> f.Id == id);
        }
    }
}

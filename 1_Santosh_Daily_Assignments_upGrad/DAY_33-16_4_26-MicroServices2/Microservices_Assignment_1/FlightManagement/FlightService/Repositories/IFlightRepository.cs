using FlightService.Model;

namespace FlightService.Service
{
    public interface IFlightRepository
    {
        List<Flight> GetAll();
        Flight GetById(int id);
        Flight Create(Flight flight);
    }
}

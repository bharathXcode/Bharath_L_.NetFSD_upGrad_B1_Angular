using FlightAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FlightAPI.Repositories
{
    public class FlightRepository
    {
        private static readonly List<Flight> _flights = new List<Flight>();
        private static int _nextId = 1;

        public Flight AddFlight(Flight flight)
        {
            flight.Id = _nextId++;
            _flights.Add(flight);
            return flight;
        }

        public Flight? GetFlight(int id)
        {
            return _flights.FirstOrDefault(f => f.Id == id);
        }

        public List<Flight> GetAllFlights()
        {
            return new List<Flight>(_flights);
        }

        public Flight? EditFlight(int id, Flight updatedFlight)
        {
            var existingFlight = GetFlight(id);
            if (existingFlight == null)
                return null;

            existingFlight.FlightCode = updatedFlight.FlightCode;
            existingFlight.Seat = updatedFlight.Seat;
            existingFlight.FlightType = updatedFlight.FlightType;
            existingFlight.Company = updatedFlight.Company;

            return existingFlight;
        }

        public bool DeleteFlight(int id)
        {
            var flight = GetFlight(id);
            if (flight == null)
                return false;

            return _flights.Remove(flight);
        }
    }
}
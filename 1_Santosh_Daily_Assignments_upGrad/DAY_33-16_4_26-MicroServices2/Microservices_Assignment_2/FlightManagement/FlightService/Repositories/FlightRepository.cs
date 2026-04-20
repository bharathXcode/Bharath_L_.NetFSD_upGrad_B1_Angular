using FlightService.Data;
using FlightService.Model;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Service
{
    public class FlightRepository:IFlightRepository
    {
        private readonly FlightDBContext _context;

        public FlightRepository(FlightDBContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Flight flight)
        {
            await _context.AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var flight=await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Flight>> GetAllAsync()
        {
           return await _context.Flights.ToListAsync();
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            return await _context.Flights.FindAsync(id);
        }

        public async Task UpdateAsync(int id,Flight flight)
        {
            var existing=await _context.Flights.FindAsync(id);
            if(existing != null)
            {
                existing.FlightNumber= flight.FlightNumber;
                existing.Source=flight.Source;
                existing.Destination=flight.Destination;
                await _context.SaveChangesAsync();
            }
        }
    }
}

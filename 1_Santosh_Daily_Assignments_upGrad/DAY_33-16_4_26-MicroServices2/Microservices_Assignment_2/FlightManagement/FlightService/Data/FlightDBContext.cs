using FlightService.Model;
using Microsoft.EntityFrameworkCore;

namespace FlightService.Data
{
    public class FlightDBContext:DbContext
    {
        public FlightDBContext(DbContextOptions<FlightDBContext> options):base(options) { }
        public DbSet<Flight> Flights { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using PassengerService.Data;
using PassengerService.Model;

namespace PassengerService.Repositories
{
    public class PassengerRepository:IPassengerRepository
    {
        private readonly PassengerDbContext _context;

        public PassengerRepository(PassengerDbContext context)
        {
            _context = context;
        }

        public async Task Create(Passenger passenger)
        {
            await _context.AddAsync(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Passenger>> GetAll()
        {
            return await _context.Passengers.ToListAsync();
        }
    }
}

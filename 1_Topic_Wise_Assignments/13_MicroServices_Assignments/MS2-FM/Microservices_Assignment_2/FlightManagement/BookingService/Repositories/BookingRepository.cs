using BookingService.Data;
using BookingService.Model;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Services
{
    public class BookingRepository:IBookingRepository
    {
        private readonly BookingDbContext _context;

        public BookingRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Booking booking)
        {
            _context.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }
    }
}

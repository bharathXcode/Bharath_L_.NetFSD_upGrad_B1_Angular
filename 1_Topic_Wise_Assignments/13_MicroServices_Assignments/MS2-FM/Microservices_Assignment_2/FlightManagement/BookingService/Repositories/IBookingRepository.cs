using BookingService.Model;

namespace BookingService.Services
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task CreateAsync(Booking booking);
    }
}

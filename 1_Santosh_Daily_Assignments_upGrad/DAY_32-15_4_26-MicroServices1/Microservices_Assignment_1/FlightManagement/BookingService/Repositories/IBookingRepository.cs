using BookingService.Model;

namespace BookingService.Services
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();
        Booking Create(Booking booking);
    }
}

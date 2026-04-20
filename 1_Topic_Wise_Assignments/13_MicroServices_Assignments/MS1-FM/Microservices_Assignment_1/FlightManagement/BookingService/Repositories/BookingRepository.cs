using BookingService.Model;

namespace BookingService.Services
{
    public class BookingRepository:IBookingRepository
    {
        private static List<Booking> bookings = new List<Booking>
        {
            new Booking{BookingId=101,FightId=1,PassengerId=201}
        };

        public Booking Create(Booking booking)
        {
            bookings.Add(booking);
            return booking;
        }

        public List<Booking> GetAll()
        {
            return bookings;
        }
    }
}

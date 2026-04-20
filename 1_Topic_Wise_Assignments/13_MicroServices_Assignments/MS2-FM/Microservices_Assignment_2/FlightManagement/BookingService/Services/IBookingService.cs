using BookingService.DTOs;

namespace BookingService.Services
{
    public interface IBookingService
    {
        Task<List<ReadBookingDto>> GetAllBookingsAsync();
        Task<ReadBookingDto> GetBookingByIdAsync(int id);
        Task CreateBookingAsync(CreateBookingDto dto);
    }
}

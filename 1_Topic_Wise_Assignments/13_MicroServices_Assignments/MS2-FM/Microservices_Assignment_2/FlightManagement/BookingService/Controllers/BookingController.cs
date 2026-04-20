using BookingService.DTOs;
using BookingService.Model;
using BookingService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }

        [HttpPost("NewBooking")]
        public async Task<IActionResult> AddBooking([FromBody]CreateBookingDto bookingDto)
        {
            await _service.CreateBookingAsync(bookingDto);
            return Ok();    
        }

        [HttpGet("AllBooking")]
        public async Task<IActionResult> GetBookings()
        {
            var bookings=await _service.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("BookingById/{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking=await _service.GetBookingByIdAsync(id);
            return Ok(booking);
        }
    }
}

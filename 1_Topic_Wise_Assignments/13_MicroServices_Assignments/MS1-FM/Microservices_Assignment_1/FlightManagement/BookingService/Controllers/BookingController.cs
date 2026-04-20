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
        private readonly IBookingRepository _repository;

        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            return Ok(_repository.Create(booking));
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            return Ok(_repository.GetAll());
        }
    }
}

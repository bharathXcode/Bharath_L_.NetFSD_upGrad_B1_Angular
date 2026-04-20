using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassengerService.Model;
using PassengerService.Repositories;

namespace PassengerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _repository;

        public PassengerController(IPassengerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetPassengers()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public IActionResult AddPassenger(Passenger passenger)
        {
            return Ok(_repository.Create(passenger));
        }
    }
}

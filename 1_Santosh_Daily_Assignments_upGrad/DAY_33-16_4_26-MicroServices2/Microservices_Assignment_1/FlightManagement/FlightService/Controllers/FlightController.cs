using FlightService.Model;
using FlightService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightRepository _repository;

        public FlightController(IFlightRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetFlights()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetFlight(int id)
        {
            var flight=_repository.GetById(id);
            return Ok(flight);
        }

        [HttpPost]
        public IActionResult AddFlight([FromBody] Flight flight)
        {
            return Ok(_repository.Create(flight));
        }
    }
}

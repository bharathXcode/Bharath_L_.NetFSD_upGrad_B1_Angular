using FlightAPI.Models;
using FlightAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightRepository _flightRepository;

        public FlightController()
        {
            _flightRepository = new FlightRepository();
        }

        [HttpGet]
        public ActionResult<List<Flight>> GetAll()
        {
            var flights = _flightRepository.GetAllFlights();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public ActionResult<Flight> Get(int id)
        {
            var flight = _flightRepository.GetFlight(id);
            if (flight == null)
                return NotFound($"Flight with ID {id} not found");

            return Ok(flight);
        }

        [HttpPost]
        public ActionResult<Flight> Add([FromBody] Flight flight)
        {
            if (string.IsNullOrEmpty(flight.FlightCode) ||
                string.IsNullOrEmpty(flight.FlightType) ||
                string.IsNullOrEmpty(flight.Company))
            {
                return BadRequest("FlightCode, FlightType, and Company are required");
            }

            if (flight.Seat <= 0)
            {
                return BadRequest("Seat count must be greater than 0");
            }

            var createdFlight = _flightRepository.AddFlight(flight);
            return CreatedAtAction(nameof(Get), new { id = createdFlight.Id }, createdFlight);
        }

        [HttpPut("{id}")]
        public ActionResult<Flight> Edit(int id, [FromBody] Flight flight)
        {
            if (id != flight.Id)
            {
                return BadRequest("ID mismatch");
            }

            var updatedFlight = _flightRepository.EditFlight(id, flight);
            if (updatedFlight == null)
                return NotFound($"Flight with ID {id} not found");

            return Ok(updatedFlight);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deleted = _flightRepository.DeleteFlight(id);
            if (!deleted)
                return NotFound($"Flight with ID {id} not found");

            return NoContent();
        }
    }
}
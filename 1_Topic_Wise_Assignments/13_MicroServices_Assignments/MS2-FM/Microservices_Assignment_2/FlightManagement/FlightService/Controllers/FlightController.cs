using FlightService.DTOs;
using FlightService.Model;
using FlightService.Service;
using FlightService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("GetAllFlights")]
        public async Task<IActionResult> GetFlights()
        {
           return Ok(await _flightService.GetAllFlightAsync());
        }

        [HttpGet("GetFlightById/{id}")]
        public async Task<IActionResult> GetFlight(int id)
        {
            var flight=await _flightService.GetFlightByIdAsync(id);
            return Ok(flight);
        }

        [HttpPost("AddFlight")]
        public async Task<IActionResult> AddFlight([FromBody] CreateFlightDto flight)
        {
            await _flightService.AddFlightAsync(flight);
            return Ok();
        }

        [HttpPut("UpdateFlight/{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] UpdateFlightDto flight)
        {
            await _flightService.UpdateFlightAsync(id, flight);
            return Ok();
        }

        [HttpDelete("DeleteFlight")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            await _flightService.DeleteFlightAsync(id);
            return Ok();
        }
    }
}

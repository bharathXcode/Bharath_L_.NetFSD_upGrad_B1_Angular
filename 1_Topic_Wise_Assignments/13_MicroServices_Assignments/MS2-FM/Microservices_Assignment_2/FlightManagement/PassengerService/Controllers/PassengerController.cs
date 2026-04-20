using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassengerService.DTOs;
using PassengerService.Model;
using PassengerService.Repositories;
using PassengerService.Services;

namespace PassengerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _service;

        public PassengerController(IPassengerService service)
        {
            _service = service;
        }

        [HttpGet("GetAllPassengers")]
        public async Task<IActionResult> GetPassengers()
        {
            return Ok(await _service.GetAllPassenger());
        }

        [HttpPost("AddPassenger")]
        public async Task<IActionResult> AddPassenger([FromBody]CreatePassengerDto dto)
        {
            await _service.CreatePassenger(dto);
            return Ok();
        }
    }
}

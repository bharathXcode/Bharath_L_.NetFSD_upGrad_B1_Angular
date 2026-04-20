using Asp.net_Core_Assignment_1.DTOs.Doctors;
using Asp.net_Core_Assignment_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors=await _doctorService.GetAllAsync();
            return Ok(doctors);
        }

        [HttpPost("AddDoctor")]
        public async Task<IActionResult> AddDoctor([FromBody]DoctorCreateDto dto)
        {
            await _doctorService.CreateAsync(dto);
            return StatusCode(201, new { message = "Doctor Created Successfully" });
        }

        [HttpGet("GetDoctor/{Specialization}")]
        public async Task<IActionResult> GetDoctor([FromRoute]string Specialization)
        {
            var dotor=await _doctorService.GetBySpecializationAsync(Specialization);
            return Ok(dotor);
        }
        [HttpDelete("DeleteDoctor/{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorService.DeleteAsync(id);
            return Ok(new { message = "Doctor Deleted Successfully" });
        }
    }
}

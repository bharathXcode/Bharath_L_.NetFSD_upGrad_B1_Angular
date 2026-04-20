using Asp.net_Core_Assignment_1.DTOs.Prescriptions;
using Asp.net_Core_Assignment_1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Assignment_1.Controllers
{
    [ApiController]
    [Route("api/prescription")]
    [Authorize(Roles ="PrescriptionAdmin")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet("Appointment/{appoinmentId}")]
        public async Task<IActionResult> GetByAppointmentId(int appoinmentId)
        {
            return Ok(await _prescriptionService.GetByAppointmentIdAsync(appoinmentId));
        }

        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddApointment([FromBody] PrescriptionCreateDto dto)
        {
            await _prescriptionService.CreateAsync(dto);
            return StatusCode(201, new { message = "Prescription Created Successfully" });
        }
    }
}

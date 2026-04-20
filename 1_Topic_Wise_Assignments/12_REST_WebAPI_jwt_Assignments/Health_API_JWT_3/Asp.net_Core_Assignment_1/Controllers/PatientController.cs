using Asp.net_Core_Assignment_1.DTOs.Patients;
using Asp.net_Core_Assignment_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Assignment_1.Controllers
{
    [ApiController]
    [Route("api/Patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _patientService.GetAllAsync();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetPatient/{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            try
            {
                var patient = await _patientService.GetByIdAsync(id);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddPatient")]
        public async Task<IActionResult> AddPatient([FromBody]PatientCreateDto dto)
        {
            try
            {
                await _patientService.CreateAsync(dto);
                return StatusCode(201, new { message = "Patient Created Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("Update/{id}")]
        public async Task<IActionResult> UpdatePatient(int id,[FromBody]PatientUpdateDto dto)
        {
            try
            {
                await _patientService.UpdateAsync(id, dto);
                return Ok(new { message = "Patient Updated Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _patientService.DeleteAsync(id);
                return Ok(new { message = "Patient Deleted Successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

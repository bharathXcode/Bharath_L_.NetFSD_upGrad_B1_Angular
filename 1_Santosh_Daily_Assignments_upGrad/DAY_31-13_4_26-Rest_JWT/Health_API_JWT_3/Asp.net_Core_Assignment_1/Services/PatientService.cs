using Asp.net_Core_Assignment_1.DTOs.Patients;
using Asp.net_Core_Assignment_1.Entities;
using Asp.net_Core_Assignment_1.Exceptions;
using Asp.net_Core_Assignment_1.Repositories;

namespace Asp.net_Core_Assignment_1.Services
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public PatientService(IPatientRepository patientRepository,IAppointmentRepository appointmentRepository)
        {
            _patientRepository= patientRepository;
            _appointmentRepository= appointmentRepository;
        }

        public async Task CreateAsync(PatientCreateDto dto)
        {
            var patient = new Patient
            {
                Name= dto.Name,
                Age= dto.Age,
                Gender= dto.Gender,
                ContactNumber= dto.ContactNumber,
                Address= dto.Address,
                CreateDate=DateTime.Now
            };
            await _patientRepository.AddPatient(patient);
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            if (patient == null)
            {
                throw new NotFoundException($"Patient with id {id} not found");
            }
            var appointments = await _appointmentRepository.GetAppointmentByPatientId(id);
            if(appointments.Count() > 0)
            {
                throw new BadRequestException("Cannot delete patient because appointments exist.cancel or remove appointments first.");
            }
            await _patientRepository.DeletePatient(patient);
        }

        public async Task<List<PatientReadDto>> GetAllAsync()
        {
            var patients = await _patientRepository.GetAllPatients();
            return patients.Select(MapToReadDto).ToList();
        }

        public async Task<PatientReadDto> GetByIdAsync(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            if(patient== null)
            {
                throw new NotFoundException($"Patient with id {id} not found");
            }
            return MapToReadDto(patient);
        }

        private static PatientReadDto MapToReadDto(Patient patient)
        {
            return new PatientReadDto
            {
                PatientId=patient.PatientId,
                Name=patient.Name,
                Age=patient.Age,
                Gender=patient.Gender,
                ContactNumber=patient.ContactNumber,
                Address=patient.Address,
                CreatedDate=patient.CreateDate
            };
        }

        public async Task UpdateAsync(int id, PatientUpdateDto dto)
        {
            var patient=await _patientRepository.GetPatient(id);
            if(patient== null)
            {
                throw new NotFoundException($"Patient with id {id} not found");
            }
            patient.Age = dto.Age;
            patient.ContactNumber= dto.ContactNumber;
            patient.Address = dto.Address;
            await _patientRepository.UpdatePatient(patient);
        }
    }
}

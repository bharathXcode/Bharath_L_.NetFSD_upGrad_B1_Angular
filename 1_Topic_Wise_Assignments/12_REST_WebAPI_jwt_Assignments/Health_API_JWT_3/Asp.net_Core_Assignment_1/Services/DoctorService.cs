using Asp.net_Core_Assignment_1.DTOs.Doctors;
using Asp.net_Core_Assignment_1.Entities;
using Asp.net_Core_Assignment_1.Exceptions;
using Asp.net_Core_Assignment_1.Repositories;

namespace Asp.net_Core_Assignment_1.Services
{
    public class DoctorService:IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public DoctorService(IDoctorRepository doctorRepository,IAppointmentRepository appointmentRepository)
        {
            _doctorRepository = doctorRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task CreateAsync(DoctorCreateDto dto)
        {
            var doctor = new Doctor
            {
                Name = dto.Name,
                Specialization = dto.Specialization,
                Experience = dto.Experience,
                ConsultationFee = dto.ConsultationFee,
            };
            await _doctorRepository.AddDoctor(doctor);
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _doctorRepository.GetDoctor(id);
            if(doctor != null)
            {
                throw new NotFoundException($"Doctor with id {id} not found");
            }
            var appointments = await _appointmentRepository.GetAppointmentByDoctorId(id);
            if(appointments.Count>0)
            {
                throw new BadRequestException($"Cannot delete doctor because appointments exist.");
            }
            await _doctorRepository.DeleteDoctor(doctor);
        }

        public async Task<List<DoctorReadDto>> GetAllAsync()
        {
            var doctors = await _doctorRepository.GetAllDoctors();
            return doctors.Select(MapToReadDto).ToList();
        }

        public async Task<List<DoctorReadDto>> GetBySpecializationAsync(string specialization)
        {
            var doctors = await _doctorRepository.GetDoctorBySpecialization(specialization);
            return doctors.Select(MapToReadDto).ToList();
        }

        private static DoctorReadDto MapToReadDto(Doctor doctor)
        {
            return new DoctorReadDto
            {
                DoctorId=doctor.DoctorId,
                Name=doctor.Name,
                Specialization=doctor.Specialization,
                Experience=doctor.Experience,
                ConsultationFee=doctor.ConsultationFee
            };
        }
    }
}

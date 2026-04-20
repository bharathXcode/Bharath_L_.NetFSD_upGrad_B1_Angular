using Asp.net_Core_Assignment_1.DTOs.Appointments;
using Asp.net_Core_Assignment_1.Entities;
using Asp.net_Core_Assignment_1.Exceptions;
using Asp.net_Core_Assignment_1.Repositories;

namespace Asp.net_Core_Assignment_1.Services
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository,IPatientRepository patientRepository,IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task CancelAsync(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            
        }

        public async Task CreateAsync(AppointmentCreateDto dto)
        {
            var patient = await _patientRepository.GetPatient(dto.PatientId);
            if(patient== null)
            {
                throw new NotFoundException($"Patient with id {dto.PatientId} not found");
            }

            var doctor=await _doctorRepository.GetDoctor(dto.DoctorId);
            if(doctor== null)
            {
                throw new NotFoundException($"Doctor with id {dto.DoctorId} not found");
            }

            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                Status = AppointmentStatus.Booked
            };

            await _appointmentRepository.AddAppointment(appointment);
        }

        public async Task<List<AppointmentReadDto>> GetAllAsync()
        {
            var appointments = await _appointmentRepository.GetAllAppointments();
            return appointments.Select(MapToReadDto).ToList();
        }

        public async Task<List<AppointmentReadDto>> GetByPatientIdAsync(int patientId)
        {
            var appointments = await _appointmentRepository.GetAppointmentByPatientId(patientId);
            return appointments.Select(MapToReadDto).ToList();
        }

        private static AppointmentReadDto MapToReadDto(Appointment appointment)
        {
            return new AppointmentReadDto
            {
                AppointmentId = appointment.AppointmentId,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient.Name,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor.Name,
                Specialization = appointment.Doctor.Specialization,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status
            };
        }
    }
}

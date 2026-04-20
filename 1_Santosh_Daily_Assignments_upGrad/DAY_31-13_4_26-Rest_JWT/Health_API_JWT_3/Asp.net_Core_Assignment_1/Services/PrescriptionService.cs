using Asp.net_Core_Assignment_1.DTOs.Prescriptions;
using Asp.net_Core_Assignment_1.Entities;
using Asp.net_Core_Assignment_1.Exceptions;
using Asp.net_Core_Assignment_1.Repositories;

namespace Asp.net_Core_Assignment_1.Services
{
    public class PrescriptionService:IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository,IAppointmentRepository appointmentRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task CreateAsync(PrescriptionCreateDto dto)
        {
            var appointment = await _appointmentRepository.GetAppointment(dto.AppointmentId);
            if (appointment == null)
            {
                throw new NotFoundException($"Appointment with id{dto.AppointmentId} not found");
            }
            var existing = await _prescriptionRepository.GetPrescriptionByAppointmentId(dto.AppointmentId);
            if(existing == null)
            {
                throw new ConflictException($"Prescription already exists for this appointment");
            }

            var prescription = new Prescription
            {
                AppointmentId = dto.AppointmentId,
                Diagnosis = dto.Diagonsis,
                Medicines = dto.Diagonsis,
                Notes = dto.Notes
            };
            await _prescriptionRepository.AddPrescription(prescription);
        }

        public async Task<PrescriptionReadDto> GetByAppointmentIdAsync(int appointmentId)
        {
            var prescription = await _prescriptionRepository.GetPrescriptionByAppointmentId(appointmentId);
            if(prescription == null)
            {
                throw new NotFoundException($"Prescription for appointment id {appointmentId} not found");
            }
            return MapToReadDto(prescription);
        }

        private static PrescriptionReadDto MapToReadDto(Prescription p)
        {
            return new PrescriptionReadDto
            {
                PrescriptionId = p.PrescriptionId,
                AppointmentId = p.AppointmentId,
                Diagnosis = p.Diagnosis,
                Medicines = p.Medicines,
                Notes = p.Notes
            };
        }
    }
}

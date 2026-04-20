using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs.Appointments
{
    public class AppointmentCreateDto
    {
        [Required]
        public int PatientId {  get; set; }

        [Required]
        public int DoctorId {  get; set; }

        public DateTime AppointmentDate {  get; set; }
    }
}

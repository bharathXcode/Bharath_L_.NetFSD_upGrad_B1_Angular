using Asp.net_Core_Assignment_1.Entities;

namespace Asp.net_Core_Assignment_1.DTOs.Appointments
{
    public class AppointmentReadDto
    {
        public int AppointmentId {  get; set; }
        public int PatientId {  get; set; }
        public string PatientName { get; set; } = string.Empty;
        public int DoctorId {  get; set; }
        public string DoctorName { get; set; }=string.Empty;
        public string Specialization {  get; set; } = string.Empty;
        public DateTime AppointmentDate {  get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Booked;
    }
}

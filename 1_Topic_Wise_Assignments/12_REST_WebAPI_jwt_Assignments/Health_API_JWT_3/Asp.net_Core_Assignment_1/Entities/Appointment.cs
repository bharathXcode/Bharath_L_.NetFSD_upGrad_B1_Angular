namespace Asp.net_Core_Assignment_1.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int PatientId {  get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.Booked;
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public Prescription? Prescription { get; set; }
    }
}

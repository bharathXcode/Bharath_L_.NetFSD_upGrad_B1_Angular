namespace Asp.net_Core_Assignment_1.Entities
{
    public class Doctor
    {
        public int DoctorId {  get; set; }
        public string? Name {  get; set; }
        public string? Specialization { get; set; }
        public int Experience { get; set; }
        public decimal ConsultationFee { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

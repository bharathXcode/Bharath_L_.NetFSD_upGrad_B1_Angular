namespace Asp.net_Core_Assignment_1.Entities
{
    public class Patient
    {
        public int PatientId {  get; set; }
        public string? Name {  get; set; }
        public int Age { get; set; }
        public string? Gender {  get; set; }
        public string? ContactNumber {  get; set; }
        public string? Address {  get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

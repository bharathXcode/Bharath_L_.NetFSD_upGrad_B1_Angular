namespace Asp.net_Core_Assignment_1.DTOs.Patients
{
    public class PatientReadDto
    {
        public int PatientId {  get; set; }
        public string Name {  get; set; }=string.Empty;
        public int Age {  get; set; }
        public string Gender { get; set; } = string.Empty;
        public string ContactNumber {  get; set; } = string.Empty;
        public string? Address {  get; set; }
        public DateTime CreatedDate {  get; set; }
    }
}

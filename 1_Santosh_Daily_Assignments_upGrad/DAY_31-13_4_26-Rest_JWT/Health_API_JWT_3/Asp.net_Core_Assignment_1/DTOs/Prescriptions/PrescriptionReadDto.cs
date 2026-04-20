namespace Asp.net_Core_Assignment_1.DTOs.Prescriptions
{
    public class PrescriptionReadDto
    {
        public int PrescriptionId {  get; set; }
        public int AppointmentId {  get; set; }
        public string Diagnosis {  get; set; }=string.Empty;
        public string Medicines {  get; set; }=string.Empty;
        public string? Notes { get; set; }
    }
}

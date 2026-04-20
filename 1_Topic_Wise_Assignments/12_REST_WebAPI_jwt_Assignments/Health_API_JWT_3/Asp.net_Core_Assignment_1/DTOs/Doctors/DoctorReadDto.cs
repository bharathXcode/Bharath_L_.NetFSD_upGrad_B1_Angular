namespace Asp.net_Core_Assignment_1.DTOs.Doctors
{
    public class DoctorReadDto
    {
        public int DoctorId {  get; set; }
        public string Name {  get; set; }=string.Empty;
        public string Specialization {  get; set; }=string.Empty;
        public int Experience {  get; set; }
        public decimal ConsultationFee {  get; set; }
    }
}

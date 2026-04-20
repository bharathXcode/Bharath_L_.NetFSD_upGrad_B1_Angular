using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs.Doctors
{
    public class DoctorCreateDto
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }=string.Empty;

        [Required,MaxLength(100)]
        public string Specialization {  get; set; }= string.Empty;

        [Range(0,60)]
        public int Experience {  get; set; }

        [Range(0, 100000)]
        public decimal ConsultationFee {  get; set; }
    }
}

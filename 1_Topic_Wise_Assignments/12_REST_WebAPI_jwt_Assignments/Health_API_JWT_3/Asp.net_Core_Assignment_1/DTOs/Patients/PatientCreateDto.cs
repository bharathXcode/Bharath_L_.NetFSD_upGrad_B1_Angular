using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs.Patients
{
    public class PatientCreateDto
    {
        [Required,MaxLength(100)]
        public string Name {  get; set; }=string.Empty;

        [Range(1,120)]
        public int Age {  get; set; }

        [Required, MaxLength(20)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^[5-9][0-9]{9}$")]
        public string ContactNumber {  get; set; }= string.Empty;
        [MaxLength(250)]
        public string? Address {  get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs.Patients
{
    public class PatientUpdateDto
    {

        [Range(1,120)]
        public int Age {  get; set; }

        [Required]
        [RegularExpression(@"^[5-9][0-9]{9}$")]
        public string ContactNumber { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Address {  get; set; }
    }
}

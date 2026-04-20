using System.ComponentModel.DataAnnotations;

namespace Asp.net_Core_Assignment_1.DTOs.Prescriptions
{
    public class PrescriptionCreateDto
    {
        [Required]
        public int AppointmentId {  get; set; }

        [Required, MaxLength(200)]
        public string Diagonsis { get; set; } = string.Empty;

        [Required, MaxLength(500)]
        public string Medicines {  get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Notes { get; set; }
    }
}

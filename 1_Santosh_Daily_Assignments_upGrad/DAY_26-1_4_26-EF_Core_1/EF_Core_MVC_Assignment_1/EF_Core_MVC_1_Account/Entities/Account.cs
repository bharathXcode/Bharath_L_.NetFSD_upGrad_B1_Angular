using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core_MVC_1_Account.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [Display(Name = "Account Type")]
        public string AccountType { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Customer { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        public string Brach { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime CreateDate { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    public class Insuree
    {
        // Primary key for the Insuree.
        public int Id { get; set; }

        // Insuree's first name.
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        // Insuree's last name.
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        // Insuree's email address.
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; } = string.Empty;

        // Insuree's date of birth.
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        // Year of the insuree's car.
        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        // Make of the insuree's car.
        [Required]
        [Display(Name = "Car Make")]
        public string CarMake { get; set; } = string.Empty;

        // Model of the insuree's car.
        [Required]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; } = string.Empty;

        // Indicates whether the insuree has ever had a DUI.
        [Display(Name = "DUI")]
        public bool DUI { get; set; }

        // Number of speeding tickets.
        [Display(Name = "Speeding Tickets")]
        public int SpeedingTickets { get; set; }

        // True means full coverage.
        // False means basic/liability coverage.
        [Display(Name = "Full Coverage")]
        public bool CoverageType { get; set; }

        // Insurance quote calculated by the application.
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quote { get; set; }
    }
}

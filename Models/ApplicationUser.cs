using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_Register_Function.Models
{
    public class ApplicationUser {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be 10 digits")]

        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not Match")]
        public string ConfirmPassword { get; set; }
    }
}




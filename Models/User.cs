using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Login_Register_Function.Models
{
    public class User
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        [Required(ErrorMessage ="enter valid email")]
        [EmailAddress]
        [Display(Name="Ëmail Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }    

    }
}

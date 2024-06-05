using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem_Final.Models
{
    public class Employee :UserActivity
    {
        //[Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]public int Id { get; set; }
      [Key]  public int EmployeeNo { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]

        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Joined Date is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime JoinedDate { get; set; }

        [Required(ErrorMessage = "Address1 is required")]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required(ErrorMessage = "Home Town is required")]
        public string HomeTown { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be 10 digits")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(0, 9999999999.99, ErrorMessage = "Salary must be a positive number with up to two decimal places")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid salary format. Maximum two decimal places allowed.")]
        public decimal Salary { get; set; }
    }

}

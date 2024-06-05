using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem_Final.Models
{
    public class LeaveApplications : Approval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveId { get; set; }

        public int EmployeeNo { get; set; }
        public Employee Employee { get; set; }
        [Required(ErrorMessage = "Start Date is required")]

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]

        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required")]

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        [EndDateGreaterThanStartDate(ErrorMessage = "End Date must be greater than Start Date.")]

        public DateTime EndDate { get; set; }

        public string Duration {  get; set; }   
//        {
//            get
//            {
//                return (EndDate - StartDate).Days;
//            }
//}
public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        
        public int StatusId { get; set; }
        public Status Status { get; set; }
       
    }
    public class EndDateGreaterThanStartDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var leaveApplication = (LeaveApplications)validationContext.ObjectInstance;

                if (leaveApplication.StartDate > leaveApplication.EndDate)
                {
                    return new ValidationResult("End Date must be greater than Start Date.");
                }

                return ValidationResult.Success;
            }
        }
    }


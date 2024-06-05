using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem_Final.Models
{
    public class LeaveType : UserActivity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int LeaveTypeId { get; set; }

        public string LeaveTypeName { get; set; }
    }
}

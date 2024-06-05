using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem_Final.Models
{
    public class Department : UserActivity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}

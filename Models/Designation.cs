using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem_Final.Models
{
    public class Designation : UserActivity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int DesignationId { get; set; }
        public string DesignationName { get; set; }
    }
}

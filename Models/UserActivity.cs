using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementSystem_Final.Models
{
    public class UserActivity  { 
        public string? CreatedById {  get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public DateTime CreatedOn { get; set; }
        public string? ModifiedById { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public DateTime ModifiedOn { get; set;}
    }

    public class Approval
    {
        public string? CreatedById { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public DateTime CreatedOn { get; set; }
        public string? ModifiedById { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public DateTime ModifiedOn { get; set; }
        public string? ApprovedBy { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public DateTime ApprovedOn { get;set; }
    }




          

          
        
    }





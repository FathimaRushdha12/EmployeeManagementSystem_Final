using EmployeeManagementSystem_Final.Models;
using Login_Register_Function.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem_Final.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<RegisterViewModel> Account { get; set; }
        public DbSet<Department> Department{ get; set; }
        public DbSet<Designation> Designation { get; set; }

        public DbSet<LeaveType> LeaveType { get; set; }
        public DbSet<Status> Status { get; set; }

        public DbSet<LeaveApplications    > LeaveApplication { get; set; }

    }
}

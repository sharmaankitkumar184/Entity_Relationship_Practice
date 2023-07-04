using Microsoft.EntityFrameworkCore;

namespace Entity_Relationship_Practice.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeAddresses> employeeAddresses { get; set; }
    }

}

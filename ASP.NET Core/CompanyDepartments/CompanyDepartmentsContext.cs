using CompanyDepartments.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyDepartments
{
    public class CompanyDepartmentsContext : DbContext
    {

        public CompanyDepartmentsContext(DbContextOptions<CompanyDepartmentsContext> options) : base(options){ }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

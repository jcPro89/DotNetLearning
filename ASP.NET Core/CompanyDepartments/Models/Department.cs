using System.Diagnostics.Contracts;

namespace CompanyDepartments.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }   
        public string DepartmentName { get; set; }
        public string DepartmentLocation { get; set;}
        public int NumberOfEmployees { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}

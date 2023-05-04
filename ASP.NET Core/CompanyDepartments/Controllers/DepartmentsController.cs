using CompanyDepartments.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CompanyDepartments.Controllers
{
    public class DepartmentsController : Controller
    {

        private readonly CompanyDepartmentsContext _dbcontext;
        private readonly IConfiguration _configuration;

        public DepartmentsController(CompanyDepartmentsContext context, IConfiguration configuration)
        {
            _dbcontext = context;
            _configuration = configuration;
        }

        public IActionResult Index(){
            List<Department> departments = _dbcontext.Departments.Include(e => e.Employees).ToList();
            return View(departments);
        }

        public IActionResult Create()
        {
            Department department = new Department();
            department.Employees.Add(new Employee() { EmployeeId = 1});
            return PartialView("_AddDepartmentPartialView", department);
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            _dbcontext.Departments.Add(department);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

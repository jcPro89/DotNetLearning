using CompanyDepartments.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyDepartments.Controllers
{
    public class DepartmentsController : Controller
    {

        private readonly CompanyDepartmentsContext _dbcontext;

        public DepartmentsController(CompanyDepartmentsContext context)
        {
            _dbcontext = context;
        }

        public IActionResult Index()
        {
            List<Department> departments = _dbcontext.Departments.Include(e => e.Employees).ToList();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Department department = new()
            {
                NumberOfEmployees = 1
            };

            department.Employees.Add(new Employee());
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

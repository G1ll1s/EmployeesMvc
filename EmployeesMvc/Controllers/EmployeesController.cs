using EmployeesMvc.Models;
using EmployeesMvc.Services;
using EmployeesMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _depService;

        public EmployeesController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _depService = departmentService;
        }

        public IActionResult Index()
        {
           

            var allEmployees = _employeeService.GetAllEmployees();
            var allDepartments = _depService.GetAllDepartments();

            var viewModel = new EmpDepViewModel
            {
                departments = allDepartments,
                employees = allEmployees
            };

            return View(viewModel);
        }

        #region Edit
        [HttpGet("editemployee/{id}")]
        public IActionResult EditEmployee(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return View(employee);
        }

        [HttpPost("editemployee/{id}")] //Varför får jag inte ba plocka ID ur modellen??
        public IActionResult EditEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            _employeeService.UpdateEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
        #endregion Edit

        #region Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            employee.CreationTimeStamp = DateTime.Now;
            _employeeService.AddEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
        #endregion Create

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            return View(employee);
        }
    }
}

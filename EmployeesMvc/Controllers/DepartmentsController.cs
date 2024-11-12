using EmployeesMvc.Models;
using EmployeesMvc.Services;
using EmployeesMvc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMvc.Controllers
{
    [Route("departments")]
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _depService;
        private readonly IEmployeeService _empService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _depService = departmentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("create")]
        public IActionResult Create()
        {

            var selectableEmployees = _empService.GetAllEmployees();
            var model = new CreateDepartmentViewModel
            {
                SelectableEmployees = selectableEmployees,
                SelectedEmployeeIDs = new List<int>()
            };

            return View(model);
        }

        [HttpPost("create-department")]
        public IActionResult CreateDepartment(CreateDepartmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var selectedEmployees = _empService.GetEmployeesByIds(model.SelectedEmployeeIDs);

            var newDepartment = new Department
            {
                Name = model.Department.Name,
                Employees = selectedEmployees
            };

            _depService.AddDepartment(newDepartment);
            return RedirectToAction("Index" , "Employees");
        }
    }
}

using EmployeesMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private static DataService _dataService = new DataService();

        public IActionResult Index()
        {
            var allEmployees = _dataService.GetAllEmployees();

            return View(allEmployees);
        }
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
            _dataService.AddEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var employee = _dataService.GetEmployee(id);
            return View(employee);
        }

    }
}

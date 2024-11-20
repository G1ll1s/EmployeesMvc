using EmployeesMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesMvc.Controllers
{
    public class EmployeesController(IDataService _dataService) : Controller
    {
        //IDataService _dataService;

        //public EmployeesController(IDataService dataService)
        //{
        //    _dataService = dataService;
        //}

        public async Task<IActionResult> IndexAsync()
        {
            var allEmployees = await _dataService.GetAllEmployeesAsync();

            return View(allEmployees);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(Employee employee)
        {
            if (!ModelState.IsValid)           
                return View(employee);
            
            await _dataService.AddEmployee(employee);
            return RedirectToAction(nameof(IndexAsync).Replace("Async", string.Empty));
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            var employee = await _dataService.GetEmployeeAsync(id);
            return View(employee);
        }

    }
}

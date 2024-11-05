using Microsoft.AspNetCore.Mvc;

namespace EmployeesMvc.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

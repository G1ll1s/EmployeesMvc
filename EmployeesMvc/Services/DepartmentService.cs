using EmployeesMvc.Models;
using EmployeesMvc.Services.Interfaces;

namespace EmployeesMvc.Services
{
    public class DepartmentService : IDepartmentService
    {
        private List<Department> departments = [
           new Department {Id = 1, Name = "Sales" }, // Employees, = new List<Employee> { employees[2] }},
            new Department {Id = 2, Name = "HR" } // Employees = new List<Employee> { employees[1] }}
           ];

        public void AddDepartment(Department department)
        {
            departments.Add(department);
        }

        public List<Department> GetAllDepartments()
        {
            return departments
                .OrderBy(e => e.Name).ToList();
        }
    }
}

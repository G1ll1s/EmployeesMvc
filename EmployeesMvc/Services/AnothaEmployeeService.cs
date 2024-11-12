using EmployeesMvc.Models;
using EmployeesMvc.Services.Interfaces;

namespace EmployeesMvc.Services
{
    public class AnothaEmployeeService : IEmployeeService
    {
        #region Dummy data
        private List<Employee> employees = [
            new Employee { Id = 1, Name = "Cim", Email = "Cim@gmail.com", Description="esk1"},
            new Employee { Id = 2, Name = "Pim", Email = "Pim@hotmail.com", Description="Besk2"},
            new Employee { Id = 3, Name = "Jim", Email = "Jim@hotmail.com", Description="Besk3"},
            ];

        private List<Department> departments = [
            new Department {Id = 1, Name = "Warehouse" }, // Employees, = new List<Employee> { employees[2] }},
            new Department {Id = 2, Name = "Manager" } // Employees = new List<Employee> { employees[1] }}
            ];
        #endregion Dummy data
        int nextId = 4;


        public List<Employee> GetAllEmployees()
        {
            return employees
                .OrderBy(e => e.Name)
                .ThenBy(e => e.Email).ToList();
        }

        public Employee GetEmployee(int id)
        {
            return employees.SingleOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = nextId++;
            employees.Add(employee);
        }

        public void UpdateEmployee(Employee updateEmpModel)
        {
            var existingEmployee = GetEmployee(updateEmpModel.Id);
            existingEmployee.Name = updateEmpModel.Name;
            existingEmployee.Email = updateEmpModel.Email;
            existingEmployee.Description = updateEmpModel.Description;
        }

        public List<Employee> GetEmployeesByIds(List<int> selectedEmployeeIDs)
        {
            var employeeList = new List<Employee>();
            foreach (var id in selectedEmployeeIDs)
            {
                var employee = employees.SingleOrDefault(e => e.Id == id);
                employeeList.Add(employee);
            }
            return employeeList;
        }
    }
}

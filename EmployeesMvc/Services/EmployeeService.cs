using EmployeesMvc.Models;
using EmployeesMvc.Services.Interfaces;

namespace EmployeesMvc.Services
{
    public class EmployeeService : IEmployeeService
    {

        #region Dummy data
        private List<Employee> employees = [
            new Employee { Id = 1, Name = "Oscar", Email = "Test@gmail.com", Description="multiline också"},
            new Employee { Id = 2, Name = "Juan", Email = "Juan@hotmail.com", Description="bowling nånting"},
            new Employee { Id = 3, Name = "Jonas", Email = "Jonas@hotmail.com", Description="fitness is my passion"},
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

using EmployeesMvc.Models;

namespace EmployeesMvc.Services.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        List<Employee> GetEmployeesByIds(List<int> selectedEmployeeIDs);
        void UpdateEmployee(Employee updateEmpModel);
    }
}
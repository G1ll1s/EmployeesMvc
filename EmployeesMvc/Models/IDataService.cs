namespace EmployeesMvc.Models
{
    public interface IDataService
    {
        Task<Employee[]> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task AddEmployee(Employee employee);
    }
}

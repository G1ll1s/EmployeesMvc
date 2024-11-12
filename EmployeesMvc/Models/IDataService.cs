namespace EmployeesMvc.Models
{
    public interface IDataService
    {
        Employee[] GetAllEmployees();
        Employee GetEmployee(int id);
        void AddEmployee(Employee employee);
    }
}

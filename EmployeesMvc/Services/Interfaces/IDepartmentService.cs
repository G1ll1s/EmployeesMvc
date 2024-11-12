using EmployeesMvc.Models;

namespace EmployeesMvc.Services.Interfaces
{
    public interface IDepartmentService
    {
        void AddDepartment(Department department);
        List<Department> GetAllDepartments();
    }
}
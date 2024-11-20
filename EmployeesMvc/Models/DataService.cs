using Microsoft.EntityFrameworkCore;

namespace EmployeesMvc.Models
{
    public class DataService(ApplicationContext _context) : IDataService
    {
        //private List<Employee> employees = [
        //    new Employee { Id = 1, Name = "Oscar", Email = "Test@gmail.com", Description="multiline också"},
        //    new Employee { Id = 2, Name = "Juan", Email = "Juan@hotmail.com", Description="bowling nånting"},
        //    new Employee { Id = 3, Name = "Jonas", Email = "Jonas@hotmail.com", Description="fitness is my passion"},
        //    ];
        //int nextId = 0;

        //ApplicationContext _context;

        //public DataService(ApplicationContext context)
        //{
        //    _context = context;
        //}
        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            return await _context.Employees
                .Include(e => e.Company)
                .OrderBy(e => e.Name)
                .ThenBy(e => e.Email)
                .ToArrayAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _context.Employees.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }
}

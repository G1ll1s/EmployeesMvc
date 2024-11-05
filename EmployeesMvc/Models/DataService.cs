namespace EmployeesMvc.Models
{
    public class DataService
    {
        private List<Employee> employees = [
            new Employee { Id = 1, Name = "Oscar", Email = "Test@gmail.com", Description="multiline också"},
            new Employee { Id = 2, Name = "Juan", Email = "Juan@hotmail.com", Description="bowling nånting"},
            new Employee { Id = 3, Name = "Jonas", Email = "Jonas@hotmail.com", Description="fitness is my passion"},
            ];
        int nextId = 0;

        public Employee[] GetAllEmployees()
        {
            return employees
                .OrderBy(e => e.Name)
                .ThenBy(e => e.Email)
                .ToArray();
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
    }
}

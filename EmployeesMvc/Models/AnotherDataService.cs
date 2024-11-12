namespace EmployeesMvc.Models
{
    public class AnotherDataService : IDataService
    {

        private List<Employee> employees = [
            new Employee { Id = 1, Name = "Test", Email = "testerson@gmail.com", Description="ping pingu pingu"},
            new Employee { Id = 2, Name = "Fantasi", Email = "fantasi@hotmail.com", Description="fantasi rullar runt i mjuka kuddar"},
            new Employee { Id = 3, Name = "Anton", Email = "anton@hotmail.com", Description="Supercoder number 1"},
            ];
        int nextId = 10;

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
            employee.Id = ++nextId;
            employees.Add(employee);
        }
    }
}

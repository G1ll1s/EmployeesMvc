namespace EmployeesMvc.Models
{
    public class CreateDepartmentViewModel
    {
        public Department? Department { get; set; }
        public List<int> SelectedEmployeeIDs { get; set; } = new List<int>();
        public IEnumerable<Employee>? SelectableEmployees { get; set; }
    }
}

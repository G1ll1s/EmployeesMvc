using System.ComponentModel.DataAnnotations;

namespace EmployeesMvc.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Must have name")]
        public string Name { get; set; }

        public List<Employee>? Employees = new List<Employee>();




    }
}

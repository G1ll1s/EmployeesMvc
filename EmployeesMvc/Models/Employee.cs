using System.ComponentModel.DataAnnotations;

namespace EmployeesMvc.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter an E-mail")]
        [EmailAddress(ErrorMessage = "Enter a valid E-mail")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }
    }
}

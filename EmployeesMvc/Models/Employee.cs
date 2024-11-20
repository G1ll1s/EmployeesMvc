using System.ComponentModel.DataAnnotations;

namespace EmployeesMvc.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter an E-mail")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

    }
}

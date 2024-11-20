namespace EmployeesMvc.Views.Employees
{
    public class IndexVM
    {
        public required EmployeeVM[] Employees { get; set; }
        public class EmployeeVM
        {
            public required string Name { get; set; }
            public required string Email { get; set; }
            public string? Description { get; set; }
            public bool ShowAsHighLighted { get; set; }

            public string? Company { get; set; }
        }
    }
}

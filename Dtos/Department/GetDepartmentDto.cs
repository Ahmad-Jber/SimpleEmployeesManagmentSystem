using EntityFrameworkTutorial.Entities;

namespace EntityFrameworkTutorial.Dtos.Department
{
    public class GetDepartmentDto
    {
        public string? Name { get; set; }
        public List<string> EmployeesName { get; set; }
    }
}

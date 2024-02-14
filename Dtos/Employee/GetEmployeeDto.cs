using EntityFrameworkTutorial.Entities;
namespace EntityFrameworkTutorial.Dtos.Employee
{
    public class GetEmployeeDto
    {
        public string? Name { get; set; }
        public string? DepartmentName { get; set; }
        public string? ManagerName { get; set; }
    }
}

namespace EntityFrameworkTutorial.Dtos.Employee
{
    public class AddEmployeeDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int? DepartmentId { get; set; }
        public int? ManagerId { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTutorial.Entities
{
    public class Employee
    {
        public int Id;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? ManagerId { get; set; }
        public Employee? Manager { get; set; }
        public List<Employee>? Subordinates { get; set; }
    }
}

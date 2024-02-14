using EntityFrameworkTutorial.Dtos.Employee;
using EntityFrameworkTutorial.Entities;

namespace EntityFrameworkTutorial.Services.Employee
{
    public interface IEmployeeService
    {
        public Task AddEmployee(AddEmployeeDto employee);
        public Task UpdateEmployee(UpdateEmployeeDto employee);
        public Task<List<GetEmployeeDto>> GetAllEmployees();
        public Task DeleteEmployee(int id);
        public Task<GetEmployeeDto> GetEmployeeById(int id);

    }
}

using EntityFrameworkTutorial.Entities;

namespace EntityFrameworkTutorial.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        public Task AddEmployee(Entities.Employee employee);
        public Task<Entities.Employee> GetEmployeeById(int id);
        public Task UpdateEmployee(Entities.Employee employee);
        public Task<List<Entities.Employee>> GetEmployees();
        public Task DeleteEmployee(int id);
    }
}

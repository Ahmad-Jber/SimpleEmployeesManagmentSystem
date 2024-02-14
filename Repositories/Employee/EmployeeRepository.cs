using EntityFrameworkTutorial.Entities;
using EntityFrameworkTutorial.Entities.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTutorial.Repositories.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationContext _context;
        public EmployeeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddEmployee(Entities.Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Entities.Employee> GetEmployeeById(int id)
        {
            var employee = _context.Employees.AsQueryable();
            employee = employee.Where(e => e.Id == id);
            employee = employee.Include(e => e.Department).Include(e=>e.Manager);
            return await employee.SingleAsync();
        }

        public async Task<List<Entities.Employee>> GetEmployees()
        {
            var employees = _context.Employees.AsQueryable();
            employees = employees.Include(e => e.Department);
            return await employees.ToListAsync();
        }

        public async Task UpdateEmployee(Entities.Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            _context.Employees.Remove(_context.Employees.Find(id));
            await _context.SaveChangesAsync();
        }
    }
}

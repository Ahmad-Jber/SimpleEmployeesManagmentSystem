using EntityFrameworkTutorial.Entities;
using EntityFrameworkTutorial.Entities.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace EntityFrameworkTutorial.Repositories.Department
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task AddDepartment(Entities.Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartment(int id)
        {
            _context.Departments.Remove(await _context.Departments.FindAsync(id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Entities.Department>> GetAllDepartments()
        {
            var departments = _context.Departments.AsQueryable();
            departments = departments.Include(d => d.Employees);
            return await departments.ToListAsync();
        }

        public async Task<Entities.Department> GetDepartmentById(int id)
        {
            var department = _context.Departments.AsQueryable();
            department = department.Where(d => d.Id == id);
            department = department.Include(d => d.Employees);
            return await department.SingleAsync();
        }

        public async Task UpdateDepartment(Entities.Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}

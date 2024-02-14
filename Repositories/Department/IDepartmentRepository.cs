namespace EntityFrameworkTutorial.Repositories.Department
{
    public interface IDepartmentRepository
    {
        public Task AddDepartment(Entities.Department department);
        public Task<List<Entities.Department>> GetAllDepartments();
        public Task<Entities.Department> GetDepartmentById(int id);
        public Task UpdateDepartment(Entities.Department department);
        public Task DeleteDepartment(int id);
    }
}

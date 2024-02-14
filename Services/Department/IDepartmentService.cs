using EntityFrameworkTutorial.Dtos.Department;

namespace EntityFrameworkTutorial.Services.Department
{
    public interface IDepartmentService
    {
        public Task AddDepartment(AddDepartmentDto department);
        public Task<List<GetDepartmentDto>> GetAllDepartments();
        public Task<GetDepartmentDto> GetDepartmentById(int id);
        public Task UpdateDepartment(UpdateDepartmentDto department);
        public Task DeleteDepartment(int id);
    }
}

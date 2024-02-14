using AutoMapper;
using EntityFrameworkTutorial.Dtos.Department;
using EntityFrameworkTutorial.Entities;
using EntityFrameworkTutorial.Repositories.Department;

namespace EntityFrameworkTutorial.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task AddDepartment(AddDepartmentDto department)
        {
            var _department = _mapper.Map<Entities.Department>(department);
            await _departmentRepository.AddDepartment(_department);
        }

        public async Task DeleteDepartment(int id)
        {
            await _departmentRepository.DeleteDepartment(id);
        }

        public async Task<List<GetDepartmentDto>> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartments();
            return _mapper.Map<List<GetDepartmentDto>>(departments);
        }

        public async Task<GetDepartmentDto> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetDepartmentById(id);
            return _mapper.Map<GetDepartmentDto>(department);
        }

        public async Task UpdateDepartment(UpdateDepartmentDto department)
        {
            var _department = _mapper.Map<Entities.Department>(department);
            await _departmentRepository.UpdateDepartment(_department);
        }
    }
}
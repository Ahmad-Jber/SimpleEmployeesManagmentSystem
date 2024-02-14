using AutoMapper;
using EntityFrameworkTutorial.Dtos.Employee;
using EntityFrameworkTutorial.Entities;
using EntityFrameworkTutorial.Repositories.Employee;

namespace EntityFrameworkTutorial.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private Entities.Employee _employee;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public async Task AddEmployee(AddEmployeeDto employeeDto)
        {
            _employee = _mapper.Map<Entities.Employee>(employeeDto);
            await _employeeRepository.AddEmployee(_employee);
        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<List<GetEmployeeDto>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            List<GetEmployeeDto> getEmployeeDtos = _mapper.Map<List<GetEmployeeDto>>(employees);
            var employeesDto = getEmployeeDtos;
            return employeesDto;
        }

        public async Task<GetEmployeeDto> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);
            var employeeDto = _mapper.Map<GetEmployeeDto>(employee);
            return employeeDto;
        }

        public async Task UpdateEmployee(UpdateEmployeeDto employee)
        {
            _employee = _mapper.Map<Entities.Employee>(employee);
            await _employeeRepository.UpdateEmployee(_employee);
        }
    }
}

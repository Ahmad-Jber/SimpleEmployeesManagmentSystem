using AutoMapper;
using EntityFrameworkTutorial.Dtos.Department;
using EntityFrameworkTutorial.Dtos.Employee;
using EntityFrameworkTutorial.Entities;

namespace EntityFrameworkTutorial.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //EmployeeProfile
            CreateMap<Employee, GetEmployeeDto>().ForMember(s=>s.Name, d=>d.MapFrom(a=>$"{a.FirstName} {a.LastName}")).ForMember(s => s.ManagerName, d => d.MapFrom(a => $"{a.Manager.FirstName} {a.Manager.LastName}"));;
            CreateMap<AddEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            //DepartmentProfile
            CreateMap<Department, GetDepartmentDto>()
                .ForMember(x => x.EmployeesName,d => d.MapFrom(x => x.Employees.Select(x => $"{x.FirstName} {x.LastName}")));
            CreateMap<AddDepartmentDto, Department>();
            CreateMap<UpdateDepartmentDto, Department>();
        }
    }
}

using EntityFrameworkTutorial.Dtos.Department;
using EntityFrameworkTutorial.Services.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost("add-department")]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentDto departmentDto)
        {
            await _departmentService.AddDepartment(departmentDto);
            return Ok();
        }
        [HttpDelete("delete-department")]
        public async Task<IActionResult> DeleteDepartment([FromQuery] int id)
        {
            await _departmentService.DeleteDepartment(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartments();
            return Ok(departments);
        }
        [HttpGet("get-department-by-id")]
        public async Task<IActionResult> GetDepartmentById([FromQuery] int id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            return Ok(department);
        }
        [HttpPut("update-department")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentDto departmentDto)
        {
            await _departmentService.UpdateDepartment(departmentDto);
            return Ok();
        }
    }
}

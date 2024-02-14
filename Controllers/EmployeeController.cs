using EntityFrameworkTutorial.Dtos.Employee;
using EntityFrameworkTutorial.Entities;
using EntityFrameworkTutorial.Services.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeDto employeeDto)
        {
            await _employeeService.AddEmployee(employeeDto);
            return Ok();
        }
        [HttpPut("update-employee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDto employee)
        {
            await _employeeService.UpdateEmployee(employee);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }
        [HttpDelete("delete-employee")]
        public async Task<IActionResult> DeleteEmployee([FromQuery]int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }
        [HttpGet("get_employee_from_id")]
        public async Task<IActionResult> GetEmployeeById([FromQuery]int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var employee = await _employeeService.GetEmployeeById(id);
            if(employee!=null)
            {
                return Ok(employee);
            }
            return NotFound();
        }
    }
}

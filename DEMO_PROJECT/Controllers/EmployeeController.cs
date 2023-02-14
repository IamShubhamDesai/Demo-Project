
using JobApplication.Core.Contact;
using JobApplication.Core.Domain.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DEMO_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeService;

        public EmployeeController(IEmployeeServices employeeService) 
        {
            _employeeService = employeeService;
        }
        
        [HttpGet("Employee")]
        public async Task<IActionResult> GetEmployee(long employeeID)
        {
            var Employees = await _employeeService.GetEmployeeAsync(employeeID);
            return Ok(Employees);
        }

        [HttpPost("Employee")]

        public async Task<IActionResult> PostEmployee([FromForm]EmployeeRequestModel employee)
        {
            await _employeeService.AddEmployeeAsync(employee);
            return Created("Employee", null);

        }

        [HttpDelete("employee/{id}")]

        public async Task<IActionResult> DeleteEmployee(long id)
        {
            var del = _employeeService.DeleteEmployeeAsync(id);

            return Ok(del);
        }

        [HttpGet("All Employee")]

        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await _employeeService.GetAllEmployeeAsync();
            return Ok(employees);
        }

        [HttpPut("Employee/{id}")]

        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeRequestModel employee, int id)
        {
            await _employeeService.UpdateStudentAsyc(employee, id);
            return NoContent();
        }

        
    }
}
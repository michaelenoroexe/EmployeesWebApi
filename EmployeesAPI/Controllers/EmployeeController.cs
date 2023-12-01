using EmployeesAPI.DTO.Employee;
using EmployeesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeesAPI.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/department/{departmentId}/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("/api/companies/{companyId}/employees")]
        public async Task<IActionResult> GetEmployeesForCompany(int companyId)
        {
            var employees = await _employeeRepository.GetEmployeesForCompanyAsync(companyId);

            return Ok(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForDepartment(int departmentId)
        {
            var employees = await _employeeRepository.GetEmployeesForDepartmentAsync(departmentId);

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(id);

            return Ok(employee);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployee(int departmentId, [FromBody] EmployeeForCreationDto employee)
        {
            var companyId = await _employeeRepository.CreateEmployeeAsync(departmentId, employee);

            var result = new ObjectResult(new { createdId = companyId });
            result.StatusCode = (int)HttpStatusCode.Created;

            return result;
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> PatchEmployee(int id, [FromBody] EmployeeForUpdateDto employee)
        {
            await _employeeRepository.UpdateEmployeeAsync(id, employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);

            return NoContent();
        }
    }
}

using EmployeesAPI.DTO.Department;
using EmployeesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeesAPI.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/departments")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments(int companyId)
        {
            var departments = await _departmentRepository.GetDepartmentsAsync(companyId);

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var departments = await _departmentRepository.GetDepartmentAsync(id);

            return Ok(departments);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Post(int companyId, [FromBody] DepartmentForCreationDto department)
        {
            var departmentId = await _departmentRepository.CreateDepartmentAsync(companyId, department);

            var result = new ObjectResult(new { createdId = departmentId });
            result.StatusCode = (int)HttpStatusCode.Created;

            return result;
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmentForUpdateDto department)
        {
            await _departmentRepository.UpdateDepartmentAsync(id, department);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentRepository.DeleteDepartmentAsync(id);

            return NoContent();
        }
    }
}

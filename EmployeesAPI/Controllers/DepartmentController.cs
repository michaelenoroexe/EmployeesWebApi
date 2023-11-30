using EmployeesAPI.DTO.Department;
using EmployeesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeesAPI.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/departments")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments(int companyId)
        {
            var departments = await _departmentService.GetDepartmentsAsync(companyId);

            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var departments = await _departmentService.GetDepartmentAsync(id);

            return Ok(departments);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Post(int companyId, [FromBody] DepartmentForCreationDto department)
        {
            var departmentId = await _departmentService.CreateDepartmentAsync(companyId, department);

            var result = new ObjectResult(new { createdId = departmentId });
            result.StatusCode = (int)HttpStatusCode.Created;

            return result;
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Put(int id, [FromBody] DepartmentForUpdateDto department)
        {
            await _departmentService.UpdateDepartmentAsync(id, department);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);

            return NoContent();
        }
    }
}

using EmployeesAPI.DTO.Company;
using EmployeesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeesAPI.Controllers
{
    
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companiesService;
        public CompanyController(ICompanyService companiesService) 
        {
            _companiesService = companiesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyList()
        {
            var companies = await _companiesService.GetAllCompaniesAsync();

            return Ok(companies);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto companyForCreation)
        {
            var companyId = await _companiesService.CreateCompanyAsync(companyForCreation);

            var result = new ObjectResult(new { createdId = companyId });
            result.StatusCode = (int)HttpStatusCode.Created;

            return result;
        }

        [HttpPut]
        [Route("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyForUpdateDto company)
        {
            await _companiesService.UpdateCompanyAsync(id, company);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companiesService.DeleteCompanyAsync(id);

            return NoContent();
        }
    }
}

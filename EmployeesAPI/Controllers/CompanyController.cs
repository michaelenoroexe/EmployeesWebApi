using EmployeesAPI.DTO.Company;
using EmployeesAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeesAPI.Controllers
{

    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companiesRepository;
        public CompanyController(ICompanyRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyList()
        {
            var companies = await _companiesRepository.GetAllCompaniesAsync();

            return Ok(companies);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto companyForCreation)
        {
            var companyId = await _companiesRepository.CreateCompanyAsync(companyForCreation);

            var result = new ObjectResult(new { createdId = companyId });
            result.StatusCode = (int)HttpStatusCode.Created;

            return result;
        }

        [HttpPut]
        [Route("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] CompanyForUpdateDto company)
        {
            await _companiesRepository.UpdateCompanyAsync(id, company);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companiesRepository.DeleteCompanyAsync(id);

            return NoContent();
        }
    }
}

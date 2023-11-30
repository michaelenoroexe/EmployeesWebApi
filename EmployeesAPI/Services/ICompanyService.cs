using EmployeesAPI.DTO.Company;

namespace EmployeesAPI.Services;

public interface ICompanyService
{
    public Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync();
    public Task<int> CreateCompanyAsync(CompanyForCreationDto newCompany);
    public Task UpdateCompanyAsync(int id, CompanyForUpdateDto newCompany);
    public Task DeleteCompanyAsync(int companyid);
}

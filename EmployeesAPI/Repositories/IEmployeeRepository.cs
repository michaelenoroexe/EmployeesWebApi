using EmployeesAPI.DTO.Employee;

namespace EmployeesAPI.Repositories;

public interface IEmployeeRepository
{
    /// <summary>
    /// List of employees for whole company
    /// </summary>
    public Task<IEnumerable<EmployeeDto>> GetEmployeesForCompanyAsync(int companyId);
    /// <summary>
    /// List of employees for single department of company
    /// </summary>
    public Task<IEnumerable<EmployeeDto>> GetEmployeesForDepartmentAsync(int departmentId);
    /// <summary>
    /// Get single employee information
    /// </summary>
    public Task<EmployeeDto> GetEmployeeAsync(int id);
    public Task<int> CreateEmployeeAsync(int departmentId, EmployeeForCreationDto employee);
    public Task UpdateEmployeeAsync(int id, EmployeeForUpdateDto employee);
    public Task DeleteEmployeeAsync(int id);
}

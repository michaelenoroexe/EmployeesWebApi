using EmployeesAPI.DTO.Department;

namespace EmployeesAPI.Repositories;

public interface IDepartmentRepository
{
    public Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(int companyId);
    public Task<DepartmentDto> GetDepartmentAsync(int id);
    public Task<int> CreateDepartmentAsync(int companyId, DepartmentForCreationDto department);
    public Task UpdateDepartmentAsync(int id, DepartmentForUpdateDto department);
    public Task DeleteDepartmentAsync(int id);
}

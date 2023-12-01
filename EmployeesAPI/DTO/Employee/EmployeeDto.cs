namespace EmployeesAPI.DTO.Employee;

public record EmployeeDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string Phone { get; init; } = null!;
    public int CompanyId { get; init; }
    public PassportDto Passport { get; init; } = null!;
    public DepartmentInfoDto Department { get; init; } = null!;
}

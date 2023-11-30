namespace EmployeesAPI.DTO.Employee;

public record DepartmentInfoDto
{
    public string Name { get; init; } = null!;
    public string Phone { get; init; } = null!;
}

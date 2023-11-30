namespace EmployeesAPI.DTO.Department;

public record DepartmentDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Phone { get; init; } = null!;
}

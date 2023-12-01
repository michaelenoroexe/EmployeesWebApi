namespace EmployeesAPI.DTO.Employee;

public record PassportDto
{
    public string? Type { get; init; }
    public string? Number { get; init; }
}

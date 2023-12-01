namespace EmployeesAPI.DTO.Company;

public record CompanyDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
}

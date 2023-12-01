namespace EmployeesAPI.DTO.Employee;

public record EmployeeAdditionalInfoDto
{
    // Passport info
    public string PassportNumber { get; init; } = null!;
    public string PassportType { get; init; } = null!;
    // Department Info
    public string Name { get; init; } = null!;
    public string Phone { get; init; } = null!;
}

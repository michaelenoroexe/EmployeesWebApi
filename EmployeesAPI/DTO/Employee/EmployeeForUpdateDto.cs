using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Employee;

public record EmployeeForUpdateDto
{
    public string? Name { get; init; }
    public string? Surname { get; init; }
    [RegularExpression(
        @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$",
        ErrorMessage = "Invalid employee phone number.")]
    public string? Phone { get; init; }
    public PassportDto? Passport { get; init; }
    public int? DepartmentId { get; init; }
}

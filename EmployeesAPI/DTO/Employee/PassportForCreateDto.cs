using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Employee;

public record PassportForCreateDto
{
    [Required(ErrorMessage = "Employee passport type is required field")]
    public string? Type { get; init; }
    [Required(ErrorMessage = "Employee passport number is required field")]
    public string? Number { get; init; }
}

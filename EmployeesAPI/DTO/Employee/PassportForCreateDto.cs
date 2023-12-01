using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Employee;

public record PassportForCreateDto
{
    [Required(ErrorMessage = "Employee passport type is required field")]
    [MaxLength(30, ErrorMessage = "Max length of employee passport type is 30 symbols.")]
    public string? Type { get; init; }
    [Required(ErrorMessage = "Employee passport number is required field")]
    [MaxLength(30, ErrorMessage = "Max length of passport number is 30 symbols.")]
    public string? Number { get; init; }
}

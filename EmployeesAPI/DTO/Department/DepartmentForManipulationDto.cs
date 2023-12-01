using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Department;

public abstract record DepartmentForManipulationDto
{
    [Required(ErrorMessage = "Department name is a required field.")]
    [MaxLength(50, ErrorMessage = "Max length of department name is 50 symbols.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Department phone is a required field.")]
    [RegularExpression(
        @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$",
        ErrorMessage = "Invalid department phone number.")]
    public string? Phone { get; init; }
}

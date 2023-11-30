using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Employee;

public record EmployeeForCreationDto
{
    [Required(ErrorMessage = "Employee first name is a required field.")]
    public string Name { get; init; } = null!;
    [Required(ErrorMessage = "Employee surname is a required field.")]
    public string Surname { get; init; } = null!;
    [Required(ErrorMessage = "Employee phone is a required field.")]
    [RegularExpression(
        @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$",
        ErrorMessage = "Invalid employee phone number.")]
    public string Phone { get; init; } = null!;
    [Required(ErrorMessage = "Employee passport data is required.")]
    public PassportForCreateDto Passport { get; init; } = null!;
}

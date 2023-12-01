using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Employee;

public record EmployeeForCreationDto
{
    [RegularExpression(@"^[a-zA-Z0-9а-яА-Я _]$",
        ErrorMessage = "Name contain invalid characters.")]
    [Required(ErrorMessage = "Employee first name is a required field.")]
    [MaxLength(50, ErrorMessage = "Max length of employee name is 50 symbols.")]
    public string Name { get; init; } = null!;

    [RegularExpression(@"^[a-zA-Z0-9а-яА-Я _]$",
        ErrorMessage = "Surname contain invalid characters.")]
    [Required(ErrorMessage = "Employee surname is a required field.")]
    [MaxLength(50, ErrorMessage = "Max length of employee surname is 50 symbols.")]
    public string Surname { get; init; } = null!;

    [Required(ErrorMessage = "Employee phone is a required field.")]
    [RegularExpression(
        @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$",
        ErrorMessage = "Invalid employee phone number.")]
    public string Phone { get; init; } = null!;

    [Required(ErrorMessage = "Employee passport data is required.")]
    public PassportForCreateDto Passport { get; init; } = null!;
}

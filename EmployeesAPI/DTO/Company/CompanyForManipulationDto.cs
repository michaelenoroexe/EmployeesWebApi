using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Company;

public abstract record CompanyForManipulationDto
{
    [Required(ErrorMessage = "Company name is a required field.")]
    [MaxLength(50, ErrorMessage = "Max length of company name is 50 symbols.")]
    public string? Name { get; init; }
}

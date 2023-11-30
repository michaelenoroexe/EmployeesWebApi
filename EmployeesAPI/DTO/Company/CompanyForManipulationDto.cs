using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Company;

public abstract record CompanyForManipulationDto
{
    [Required(ErrorMessage = "Company name is a required field.")]
    public string? Name { get; init; }
}

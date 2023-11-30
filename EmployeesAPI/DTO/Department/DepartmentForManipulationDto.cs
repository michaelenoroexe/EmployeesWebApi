﻿using System.ComponentModel.DataAnnotations;

namespace EmployeesAPI.DTO.Department;

public abstract record DepartmentForManipulationDto
{
    [Required(ErrorMessage = "Department name is a required field.")]
    public string? Name { get; init; }
    [RegularExpression(
        @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", 
        ErrorMessage = "Invalid department phone number.")]
    public string? Phone { get; init; }
}

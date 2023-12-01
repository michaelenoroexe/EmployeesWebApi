namespace EmployeesAPI.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? Phone { get; set; }
    public int CompanyId { get; set; }
    public Passport? Passport { get; set; }
    public Department? Department { get; set; }

}

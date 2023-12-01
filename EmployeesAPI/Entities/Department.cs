namespace EmployeesAPI.Entities;

/// <summary>
/// Department information
/// </summary>
public class Department
{
    public int Id { get; set; }
    /// <summary>
    /// Department name
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// Department contact phone number
    /// </summary>
    public string Phone { get; set; } = null!;
    public Company? Company { get; set; }
    public IEnumerable<Employee>? Employees { get; set;}
}

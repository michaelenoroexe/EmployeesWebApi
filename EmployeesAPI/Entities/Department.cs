namespace EmployeesAPI.Entities;

/// <summary>
/// Department information
/// </summary>
public record Department
{
    public int Id { get; init; }
    /// <summary>
    /// Department name
    /// </summary>
    public string Name { get; init; }
    /// <summary>
    /// Department contact phone number
    /// </summary>
    public string Phone { get; init; }
}

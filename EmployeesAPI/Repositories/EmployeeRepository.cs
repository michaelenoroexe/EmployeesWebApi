using Dapper;
using EmployeesAPI.DTO.Employee;
using Npgsql;
using System.Data;

namespace EmployeesAPI.Repositories;

public class EmployeeRepository : IEmployeeRepository, IDisposable
{
    private readonly IDbConnection db;

    /// <summary>
    /// Get employee dto from sql request.
    /// </summary>
    /// <param name="objs">Objects from dapper query splitted by passportType</param>
    private EmployeeDto GetEmployeeDtoFromParams(object[] objs)
    {
        var emp = (EmployeeDto)objs[0];
        var empInfo = (EmployeeAdditionalInfoDto)objs[1];

        return emp with
        {
            Passport = new PassportDto { Number = empInfo.PassportNumber, Type = empInfo.PassportType },
            Department = new DepartmentInfoDto { Name = empInfo.Name, Phone = empInfo.Phone }
        };
    }
    /// <summary>
    /// Get sql request to get all needed fields for employee dto
    /// </summary>
    private string GetEmployeeSqlQuery(string whereString)
    {
        return "SELECT emp.id, emp.name, emp.surname, emp.phone, companyId, " +
           "passportType, passportNumber, " +
           "dep.name, dep.phone " +
           "FROM employees as emp " +
           "JOIN departments as dep ON emp.departmentId = dep.id " +
           whereString;
    }

    public EmployeeRepository()
    {
        db = new NpgsqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING")!);
    }

    public async Task<int> CreateEmployeeAsync(int departmentId, EmployeeForCreationDto employee)
    {
        var createdEmployee = new
        {
            name = employee.Name,
            surname = employee.Surname,
            phone = employee.Phone,
            passportType = employee.Passport.Type,
            passportNumber = employee.Passport.Number,
            departmentId
        };

        var createdId = await db.QueryFirstAsync<int>(
            "INSERT INTO employees (name, surname, phone, passportType, passportNumber, departmentId)" +
            "VALUES (@name, @surname, @phone, @passportType, @passportNumber, @departmentId) " +
            "RETURNING id;",
            createdEmployee);

        return createdId;
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await db.ExecuteAsync("DELETE FROM employees WHERE id=@id", new { id });
    }

    public async Task<EmployeeDto> GetEmployeeAsync(int id)
    {
        var emp = await db.QueryAsync<EmployeeDto>(
            GetEmployeeSqlQuery("WHERE emp.id=@id ") + " LIMIT 1",
            new Type[] { typeof(EmployeeDto), typeof(EmployeeAdditionalInfoDto) },
            param: new { id },

            map: GetEmployeeDtoFromParams,
            splitOn: "passportType");

        return emp.First();
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesForCompanyAsync(int companyId)
    {
        var emp = await db.QueryAsync(
            GetEmployeeSqlQuery("WHERE companyId=@companyId"),
            new Type[] { typeof(EmployeeDto), typeof(EmployeeAdditionalInfoDto) },
            param: new { companyId },
            map: GetEmployeeDtoFromParams,
            splitOn: "passportType");

        return emp;
    }

    public async Task<IEnumerable<EmployeeDto>> GetEmployeesForDepartmentAsync(int departmentId)
    {
        var emp = await db.QueryAsync(
            GetEmployeeSqlQuery("WHERE departmentId=@departmentId"),
            new Type[] { typeof(EmployeeDto), typeof(EmployeeAdditionalInfoDto) },
            param: new { departmentId },
            map: GetEmployeeDtoFromParams,
            splitOn: "passportType");

        return emp;
    }

    public async Task UpdateEmployeeAsync(int id, EmployeeForUpdateDto employee)
    {
        List<string> updateList = new List<string>();
        if (employee.Name is not null) updateList.Add($@"name = @name");
        if (employee.Surname is not null) updateList.Add($@"surname = @surname");
        if (employee.Phone is not null) updateList.Add($@"phone = @phone");
        if (employee?.Passport?.Type is not null) updateList.Add($@"passportType = @passportType");
        if (employee?.Passport?.Number is not null) updateList.Add($@"passportNumber = @passportNumber");
        if (employee.DepartmentId.HasValue &&
            employee.DepartmentId.Value != 0) updateList.Add($@"departmentId = @departmentId");

        var createdEmployee = new
        {
            id,
            name = employee.Name,
            surname = employee.Surname,
            phone = employee.Phone,
            passportType = employee?.Passport?.Type,
            passportNumber = employee?.Passport?.Number,
            departmentId = employee?.DepartmentId
        };

        var sqlUpdateReq =
            "UPDATE employees " +
            $"SET " + string.Join(", ", updateList) + " " +
            "WHERE id = @id;";

        await db.ExecuteAsync(sqlUpdateReq, createdEmployee);
    }

    public void Dispose()
    {
        db.Dispose();
    }
}

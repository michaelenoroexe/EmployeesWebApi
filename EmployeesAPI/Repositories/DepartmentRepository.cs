using Dapper;
using EmployeesAPI.DTO.Department;
using Npgsql;
using System.Data;

namespace EmployeesAPI.Repositories;

public class DepartmentRepository : IDepartmentRepository, IDisposable
{
    private readonly IDbConnection db;

    public DepartmentRepository()
    {
        db = new NpgsqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING")!);
    }

    public async Task<int> CreateDepartmentAsync(int companyId, DepartmentForCreationDto department)
    {
        var createdDepartment = new
        {
            name = department.Name,
            phone = department.Phone,
            companyId
        };

        var createdId = await db.QueryFirstAsync<int>(
            "INSERT INTO departments (name, phone, companyId)" +
            "VALUES (@name, @phone, @companyId) " +
            "RETURNING id;",
            createdDepartment);

        return createdId;
    }

    public async Task DeleteDepartmentAsync(int id)
    {
        await db.ExecuteAsync("DELETE FROM departments WHERE id=@id", new { id });
    }

    public async Task<DepartmentDto> GetDepartmentAsync(int id)
    {
        var department = await db.QueryFirstAsync<DepartmentDto>(
            "SELECT id, name, phone " +
            "FROM departments WHERE id=@id", 
            new { id });

        return department;
    }

    public async Task<IEnumerable<DepartmentDto>> GetDepartmentsAsync(int companyId)
    {
        var companies = await db.QueryAsync<DepartmentDto>(
            "SELECT id, name, phone " +
            "FROM departments " +
            "WHERE companyId=@companyId", 
            new { companyId });

        return companies;
    }

    public async Task UpdateDepartmentAsync(int id, DepartmentForUpdateDto department)
    {
        var updatedDepartment = new
        {
            id,
            name = department.Name,
            phone = department.Phone
        };

        await db.ExecuteAsync(
            "UPDATE departments " +
            "SET name=@name, phone=@phone " +
            "WHERE id=@id",
            updatedDepartment);
    }

    public void Dispose()
    {
        db.Dispose();
    }
}

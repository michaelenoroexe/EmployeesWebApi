using Dapper;
using EmployeesAPI.DTO.Company;
using Npgsql;
using System.Data;

namespace EmployeesAPI.Repositories;

public class CompanyRepository : ICompanyRepository, IDisposable
{
    private readonly IDbConnection db;

    public CompanyRepository()
    {
        db = new NpgsqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING")!);
    }

    public async Task<int> CreateCompanyAsync(CompanyForCreationDto newCompany)
    {
        var createdId = await db.QueryFirstAsync<int>(
            "INSERT INTO companies (name)" +
            "VALUES (@name) " +
            "RETURNING id;",
            new { name = newCompany.Name });

        return createdId;
    }

    public async Task DeleteCompanyAsync(int companyId)
    {
        await db.ExecuteAsync(
            "DELETE FROM companies " +
            "WHERE id=@id",
            new { id = companyId });
    }

    public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
    {
        var companies = await db.QueryAsync<CompanyDto>("SELECT * FROM companies");

        return companies;
    }

    public async Task UpdateCompanyAsync(int id, CompanyForUpdateDto newCompany)
    {
        await db.ExecuteAsync(
            "UPDATE companies " +
            "SET name=@name " +
            "WHERE id=@id",
            new { id, name = newCompany.Name });
    }
    public void Dispose()
    {
        db.Dispose();
    }
}

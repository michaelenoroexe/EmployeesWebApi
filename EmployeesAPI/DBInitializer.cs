using Dapper;
using Npgsql;
using System.Data;

namespace EmployeesAPI;

/// <summary>
/// Class to initialize db structure
/// </summary>
public class DBInitializer : IDisposable
{
    private readonly IDbConnection connect;

    private bool IsTablesExists()
    {
        var db = connect.Query("SELECT * " +
            "FROM information_schema.tables " +
            "WHERE table_type = 'BASE TABLE' AND table_schema = 'public';");

        return db.Any();
    }
    private void CreateTables()
    {
        connect.Execute("CREATE TABLE companies" +
                        "(" +
                            "id SERIAL PRIMARY KEY," +
                            "name VARCHAR(50) UNIQUE NOT NULL" +
                        ")");

        connect.Execute("CREATE TABLE departments" +
                        "(" +
                            "id SERIAL PRIMARY KEY," +
                            "name VARCHAR(50) NOT NULL," +
                            "phone VARCHAR(16) NOT NULL," +
                            "companyId INTEGER REFERENCES Companies(Id) ON DELETE CASCADE," +
                            "UNIQUE(Name, CompanyId)" +
                        ")");

        connect.Execute("CREATE TABLE employees" +
                        "(" +
                            "id SERIAL PRIMARY KEY," +
                            "name VARCHAR(50) NOT NULL," +
                            "surname VARCHAR(50) NOT NULL," +
                            "phone VARCHAR(16) NOT NULL," +
                            "passportType VARCHAR(30) NOT NULL," +
                            "passportNumber VARCHAR(30) NOT NULL," +
                            "departmentId INTEGER REFERENCES Departments(Id) ON DELETE CASCADE" +
                        ")");
    }

    public DBInitializer()
    {
        var connStr = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;

        connect = new NpgsqlConnection(connStr);
    }

    public void Initialize()
    {
        if (!IsTablesExists())
        {
            CreateTables();
        }
    }

    public void Dispose()
    {
        connect.Dispose();
    }
}

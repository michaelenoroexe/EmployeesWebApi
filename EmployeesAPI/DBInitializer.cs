using Dapper;
using Npgsql;
using System.Data;

namespace EmployeesAPI;

/// <summary>
/// Class to initialize db structure.
/// </summary>
public class DBInitializer : IDisposable
{
    private readonly string dbName;
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
        connect.Execute("CREATE TABLE Companies" +
                        "(" +
                            "Id SERIAL PRIMARY KEY," +
                            "Name VARCHAR(50) UNIQUE NOT NULL" +
                        ")");

        connect.Execute("CREATE TABLE Departments" +
                        "(" +
                            "Id SERIAL PRIMARY KEY," +
                            "Name VARCHAR(50) NOT NULL," +
                            "Phone VARCHAR(16) NOT NULL," +
                            "CompanyId INTEGER REFERENCES Companies(Id) ON DELETE CASCADE," +
                            "UNIQUE(Name, CompanyId)" +
                        ")");

        connect.Execute("CREATE TABLE Employees" +
                        "(" +
                            "Id SERIAL PRIMARY KEY," +
                            "Name VARCHAR(50) NOT NULL," +
                            "Surname VARCHAR(50) NOT NULL," +
                            "Phone VARCHAR(16) NOT NULL," +
                            "PassportType VARCHAR(30) NOT NULL," +
                            "PassportNumber VARCHAR(30) NOT NULL," +
                            "DepartmentId INTEGER REFERENCES Departments(Id) ON DELETE CASCADE" +
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

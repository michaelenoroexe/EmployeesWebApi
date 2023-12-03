using EmployeesAPI;
using EmployeesAPI.Repositories;
using Serilog;
using Serilog.Exceptions;

Log.Logger = new LoggerConfiguration()
    .Enrich.WithExceptionDetails()
    .Enrich.WithProperty("Source", "API")
    .WriteTo.File("log.json")
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

using (var initializer = new DBInitializer())
{
    initializer.Initialize();
}

var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

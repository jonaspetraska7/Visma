using Common.Data;
using Common.Entities;
using Common.Interfaces;
using Common.Middleware;
using Common.Repositories;
using Common.Services;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLinqToDBContext<VismaDataConnection>((provider, options) => {
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("VismaDb"))
    .UseDefaultLogging(provider);
});


builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<AddEmployeeActionFilter>();
builder.Services.AddScoped<ModelStateIsValidActionFilterAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataConnection = scope.ServiceProvider.GetService<VismaDataConnection>();
    var sp = dataConnection.DataProvider.GetSchemaProvider();
    var dbSchema = sp.GetSchema(dataConnection);
    if (!dbSchema.Tables.Any(t => t.TableName == nameof(Employee)))
    {
        dataConnection.CreateTable<Employee>();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

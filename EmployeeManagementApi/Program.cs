using EmployeeManagementApi.Models;
using EmployeeManagementApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementApi.Handlers;
using EmployeeManagementApi.Queries;
using EmployeeManagementApi.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MediatR
// builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Register handlers
// builder.Services.AddTransient<IRequestHandler<GetEmployeesQuery, IEnumerable<Employee>>, GetEmployeesHandler>();
// builder.Services.AddTransient<IRequestHandler<GetEmployeeByIdQuery, Employee>, GetEmployeeByIdHandler>();
// builder.Services.AddTransient<IRequestHandler<CreateEmployeeCommand, Employee>, CreateEmployeeHandler>();
// builder.Services.AddTransient<IRequestHandler<UpdateEmployeeCommand, Employee>, UpdateEmployeeHandler>();
// builder.Services.AddTransient<IRequestHandler<DeleteEmployeeCommand, bool>, DeleteEmployeeHandler>();
// builder.Services.AddTransient<IRequestHandler<EmployeeExistsQuery, bool>, EmployeeExistsHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp"); // Add this line here
app.UseAuthorization();
app.MapControllers();

app.Run();

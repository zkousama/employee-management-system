using MediatR;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Commands;
using EmployeeManagementApi.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        private readonly ApplicationDbContext _context;

        public UpdateEmployeeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                return null;
            }

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Position = request.Position;
            employee.Department = request.Department;

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}

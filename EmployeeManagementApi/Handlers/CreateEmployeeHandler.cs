using MediatR;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Commands;
using EmployeeManagementApi.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Handlers {

    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee> {

        private readonly ApplicationDbContext _context;

        public CreateEmployeeHandler(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken) {

            var employee = new Employee {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Position = request.Position,
                Department = request.Department
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);
            
            return employee;
        }
    }
}
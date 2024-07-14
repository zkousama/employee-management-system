using MediatR;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Queries;
using EmployeeManagementApi.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Handlers {
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee> {
        private readonly ApplicationDbContext _context;
        public GetEmployeeByIdHandler(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken) {
            return await _context.Employees.FindAsync(request.Id);
        }
    }
}
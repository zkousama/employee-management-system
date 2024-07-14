using MediatR;
using EmployeeManagementApi.Queries;
using EmployeeManagementApi.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementApi.Handlers
{
    public class EmployeeExistsHandler : IRequestHandler<EmployeeExistsQuery, bool>
    {
        private readonly ApplicationDbContext _context;

        public EmployeeExistsHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(EmployeeExistsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees.AnyAsync(e => e.Id == request.Id);
        }
    }
}

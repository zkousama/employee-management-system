using MediatR;
using EmployeeManagementApi.Commands;
using EmployeeManagementApi.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly ApplicationDbContext _context;

        public DeleteEmployeeHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FindAsync(request.Id);

            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

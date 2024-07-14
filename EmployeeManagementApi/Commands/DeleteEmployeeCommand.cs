using MediatR;
using System;

namespace EmployeeManagementApi.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

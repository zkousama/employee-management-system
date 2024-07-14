using MediatR;
using System;

namespace EmployeeManagementApi.Queries
{
    public class EmployeeExistsQuery : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

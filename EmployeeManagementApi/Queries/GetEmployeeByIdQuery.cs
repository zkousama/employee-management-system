using MediatR;
using EmployeeManagementApi.Models;
using System;

namespace EmployeeManagementApi.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }
    }
}

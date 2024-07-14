using MediatR;
using EmployeeManagementApi.Models;
using System;

namespace EmployeeManagementApi.Commands
{
    public class UpdateEmployeeCommand : IRequest<Employee>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
}

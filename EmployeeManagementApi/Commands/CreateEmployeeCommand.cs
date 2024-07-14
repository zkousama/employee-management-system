using MediatR;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Commands {
    public class CreateEmployeeCommand : IRequest<Employee> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
    }
}
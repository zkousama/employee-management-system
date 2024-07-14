using MediatR;
using EmployeeManagementApi.Models;

namespace EmployeeManagementApi.Queries
{
    public class GetEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }
}
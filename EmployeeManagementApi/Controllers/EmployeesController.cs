using MediatR;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagementApi.Models;
using EmployeeManagementApi.Queries;
using EmployeeManagementApi.Commands;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _mediator.Send(new GetEmployeesQuery());
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery { Id = id });

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(CreateEmployeeCommand command)
        {
            var employee = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, UpdateEmployeeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            
            if (result == null) {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand { Id = id });
            
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        private async Task<bool> EmployeeExists(Guid id)
        {
            return await _mediator.Send(new EmployeeExistsQuery { Id = id });
        }
    }
}
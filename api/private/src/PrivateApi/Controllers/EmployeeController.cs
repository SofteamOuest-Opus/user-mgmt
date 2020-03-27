using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PrivateApi.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet("employees")]
        public IActionResult ListEmployees() => Ok(employeeService.GetEmployees());

        [HttpGet("employee/{id:guid}")]
        public IActionResult ShowEmployeeById([FromRoute] Guid id)
        {
            var employee = employeeService.GetEmployee(id);

            return employee == default
                ? NotFound()
                : (IActionResult)Ok(employee);
        }

        [HttpPut("employee/{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody][Required] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (result, updated) = await employeeService.UpdateEmployeeAsync(id, employee);
            return result switch
            {
                ServiceResult.Created => CreatedAtAction(nameof(ShowEmployeeById), new { id = updated?.Id }, updated),
                ServiceResult.Updated => Ok(updated),
                _ => BadRequest(),
            };
        }

        [HttpPost("employee")]
        public async Task<IActionResult> CreateEmployee([FromBody][Required] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (result, created) = await employeeService.CreateEmployeeAsync(employee);
            return result switch
            {
                ServiceResult.Created => CreatedAtAction(nameof(ShowEmployeeById), new { id = created?.Id }, created),
                _ => BadRequest(),
            };
        }
    }
}

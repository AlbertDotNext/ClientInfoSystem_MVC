using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmps();
            if (!employees.Any())
            {
                throw new NotFoundException("Employee not found");
            }
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmpInfoRequestModel requestModel)
        {
            var employee = await _employeeService.AddEmployee(requestModel);
            return Ok(employee);
        }

        [HttpPut]
        [Route("{Id:int}")]
        public async Task<IActionResult> UpdateEmployee(int Id, [FromBody] EmpInfoRequestModel requestModel)
        {
            var employee = await _employeeService.UpdateEmployee(Id, requestModel);

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            await _employeeService.DeleteEmployeeById(Id);

            return Ok();
        }
    }
}

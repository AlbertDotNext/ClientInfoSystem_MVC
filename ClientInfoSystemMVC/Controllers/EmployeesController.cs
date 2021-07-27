using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystemMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> EmployeeList()
        {
            var employees = await _employeeService.GetAllEmps();
            return View(employees);
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmpInfoRequestModel requestModel)
        {
            await _employeeService.AddEmployee(requestModel);
            if (!ModelState.IsValid) return View();

            return RedirectToAction("EmployeeList");
        }

        [HttpGet]
        public IActionResult UpdateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(int Id, EmpInfoRequestModel requestModel)
        {
            await _employeeService.UpdateEmployee(Id, requestModel);
            if (!ModelState.IsValid) return View();

            return RedirectToAction("EmployeeList");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeById(id);
            return RedirectToAction("EmployeeList");
        }
    }
}

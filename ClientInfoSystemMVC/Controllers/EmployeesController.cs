using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        [HttpGet]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            return View(employee);
        }

        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EmployeeLogin(EmployeeLoginRequestModel model)
        {
            if (!ModelState.IsValid) return View();

            var employee = await _employeeService.Login(model.EmployeeID, model.Name, model.Password);
            if(employee == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid password");
                return View();
            }

            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, employee.Name),
                 new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect("~/");
        }

        public async Task<ActionResult> EmployeeLogout()
        {
            await HttpContext.SignOutAsync();
            return LocalRedirect("~/");
        }
    }
}

using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmpInfoResponseModel>> GetAllEmps()
        {
            var employees = await _employeeRepository.ListAllAsync();
            var empList = new List<EmpInfoResponseModel>();
            foreach (var emp in employees)
            {
                empList.Add(new EmpInfoResponseModel
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Password = emp.Password,
                    Designation = emp.Designation
                });
            }

            return empList;
        }
    }
}

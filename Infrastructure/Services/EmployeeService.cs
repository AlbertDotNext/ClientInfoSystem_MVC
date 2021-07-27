﻿using ApplicationCore.Entities;
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

        public async Task<EmpInfoResponseModel> AddEmployee(EmpInfoRequestModel model)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation
            };

            var empResponse = new EmpInfoResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };

            var createdEmployee = await _employeeRepository.AddAsync(employee);
            return empResponse;
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

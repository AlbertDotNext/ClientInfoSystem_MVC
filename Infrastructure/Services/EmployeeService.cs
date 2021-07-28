using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IInteractionRepository _interactionRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IInteractionRepository interactionRepository)
        {
            _employeeRepository = employeeRepository;
            _interactionRepository = interactionRepository;
        }

        public async Task<EmpInfoResponseModel> AddEmployee(EmpInfoRequestModel model)
        {

            //var salt = CreateSalt();

            //var hashedPassword = HashPassword(model.Password, salt);

            var employee = new Employee
            {
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation
            };

            var createdEmployee = await _employeeRepository.AddAsync(employee);

            var empResponse = new EmpInfoResponseModel
            {
                Id = createdEmployee.Id,
                Name = createdEmployee.Name,
                Password = createdEmployee.Password,
                Designation = createdEmployee.Designation
            };

            
            return empResponse;
        }

        //private string CreateSalt()
        //{
        //    byte[] randomBytes = new byte[128 / 8];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomBytes);
        //    }

        //    return Convert.ToBase64String(randomBytes);
        //}

        //private string HashPassword(string password, string salt)
        //{
            
        //    var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //                                                            password: password,
        //                                                            salt: Convert.FromBase64String(salt),
        //                                                            prf: KeyDerivationPrf.HMACSHA512,
        //                                                            iterationCount: 10000,
        //                                                            numBytesRequested: 256 / 8));
        //    return hashed;
        //}

        public async Task DeleteEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            var employeeInteraction = await _interactionRepository.GetEmployeeInteractionsById(id);

            if (employeeInteraction.Any())
            {
                foreach (var item in employeeInteraction)
                {
                    await _interactionRepository.DeleteAsync(item);
                }
            }
            
            
            await _employeeRepository.DeleteAsync(employee);
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

        public async Task<EmpInfoResponseModel> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            var employeeResponse = new EmpInfoResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };
            return employeeResponse;
        }

        public async Task<EmpInfoResponseModel> Login(int id, string name, string password)
        {
            var dbEmployee = await _employeeRepository.GetByIdAsync(id);
            if(dbEmployee == null)
            {
                throw new NotFoundException("Employee account does not exists");
            }

            if(password == dbEmployee.Password)
            {
                var employeeResponse = new EmpInfoResponseModel
                {
                    Id = dbEmployee.Id,
                    Name = dbEmployee.Name,
                    Designation = dbEmployee.Designation

                };

                return employeeResponse;
            }

            return null;
        }

        public async Task<EmpInfoResponseModel> UpdateEmployee(int id, EmpInfoRequestModel model)
        {
            var dbEmployee = await _employeeRepository.GetByIdAsync(id);
            if (dbEmployee == null)
            {
                throw new NotFoundException("No employee found");
            }


            dbEmployee.Name = model.Name;
            dbEmployee.Password = model.Password;
            dbEmployee.Designation = model.Designation;


            var createdEmployee = await _employeeRepository.UpdateAsync(dbEmployee);
            var employeeResponse = new EmpInfoResponseModel
            {
                Id = createdEmployee.Id,
                Name = createdEmployee.Name,
                Password = createdEmployee.Password,
                Designation = createdEmployee.Designation


            };
            return employeeResponse;
        }
    }
}

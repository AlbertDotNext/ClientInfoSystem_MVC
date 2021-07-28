using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeeService
    {
        Task<List<EmpInfoResponseModel>> GetAllEmps();
        Task<EmpInfoResponseModel> AddEmployee(EmpInfoRequestModel model);
        Task<EmpInfoResponseModel> UpdateEmployee(int id, EmpInfoRequestModel model);
        Task<EmpInfoResponseModel> GetEmployeeById(int id);
        Task DeleteEmployeeById(int id);
        Task<EmpInfoResponseModel> Login(int id, string name, string password);
    }
}

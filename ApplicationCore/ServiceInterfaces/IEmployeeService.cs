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
    }
}

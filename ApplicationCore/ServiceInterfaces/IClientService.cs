using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IClientService
    {
        Task<List<ClientResponseModel>> GetAllClients();
        Task<ClientResponseModel> GetClientById(int id);
        Task<ClientResponseModel> GetClientByEmail(string email);
        Task<ClientResponseModel> AddClient(ClientRequestModel model);
        Task<ClientResponseModel> UpdateClientById(ClientRequestModel model);
        Task DeleteClientById(int id);

    }
}

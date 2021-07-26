using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
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
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        
        public async Task<List<ClientResponseModel>> GetAllClients()
        {
            var clients = await _clientRepository.ListAllAsync();
            var clientList = new List<ClientResponseModel>();
            foreach (var client in clients)
            {
                clientList.Add(new ClientResponseModel
                {
                    Id = client.Id,
                    Name = client.Name,
                    Email = client.Email,
                    Phones = client.Phones,
                    Address = client.Address,
                    AddedOn = client.AddedOn
                });
            }

            return clientList;
        }

        public async Task<ClientResponseModel> UpdateClientById(ClientRequestModel model)
        {
            var dbClient = await _clientRepository.GetByIdAsync(model.Id);
            if(dbClient == null)
            {
                throw new NotFoundException("The client is not exists, please add this client first");
            }
            var client = new Client
            {
                Id = model.Id,
                Name = model.Name,
                Phones = model.Phones,
                Email = model.Email,
                Address = model.Address
            };

            var createdClient = await _clientRepository.UpdateAsync(client);
            var clientResponse = new ClientResponseModel
            {
                Id = createdClient.Id,
                Name = createdClient.Name,
                Phones = createdClient.Phones,
                Address = createdClient.Address,
                Email = createdClient.Email
            };
            return clientResponse;
        }
    }
}

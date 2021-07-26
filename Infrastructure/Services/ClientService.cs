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


            dbClient.Name = model.Name;
            dbClient.Phones = model.Phones;
            dbClient.Email = model.Email;
            dbClient.Address = model.Address;
            dbClient.AddedOn = model.AddedOn;
           

            var createdClient = await _clientRepository.UpdateAsync(dbClient);
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

        public async Task DeleteClientById(int id)
        {
            var dbClient = await _clientRepository.GetByIdAsync(id);
            if(dbClient == null)
            {
                throw new NotFoundException("Client not exists");
            }

            await _clientRepository.DeleteAsync(dbClient);

            
        }

        public async Task<ClientResponseModel> AddClient(ClientRequestModel model)
        {
            var client = new Client
            {
                Name = model.Name,
                Phones = model.Phones,
                Email = model.Email,
                Address = model.Address,
                AddedOn = model.AddedOn
            };

            var clientResponse = new ClientResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Phones = client.Phones,
                Email = client.Email,
                Address = client.Address,
                AddedOn = client.AddedOn
            };

            var createdClient = await _clientRepository.AddAsync(client);
            return clientResponse;
        }
    }
}

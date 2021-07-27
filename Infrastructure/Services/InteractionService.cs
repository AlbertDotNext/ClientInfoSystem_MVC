using ApplicationCore.Entities;
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
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;

        public InteractionService(IInteractionRepository interactionRepository)
        {
            _interactionRepository = interactionRepository;
        }

        public async Task<InteractionResponseModel> AddInteraction(InteractionRequestModel model)
        {
            var interaction = new Interaction
            {
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks
            };

            var createdInteraction = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };

            await _interactionRepository.AddAsync(interaction);
            return createdInteraction;
        }

        public async Task<List<InteractionResponseModel>> GetInteractions()
        {
            var interactions = await _interactionRepository.GetInteractions();
            var interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                interactionList.Add(new InteractionResponseModel
                {
                    Id = interaction.Id,
                    ClientId = interaction.ClientId,
                    ClientName = interaction.Client.Name,
                    EmpId = interaction.EmpId,
                    EmployeeName = interaction.Emp.Name,
                    IntType = interaction.IntType,
                    IntDate = interaction.IntDate,
                    Remarks = interaction.Remarks

                });
            }

            return interactionList;
        }
    }
}

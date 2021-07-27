using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionService
    {
        Task<List<InteractionResponseModel>> GetInteractions();
        Task<InteractionResponseModel> AddInteraction(InteractionRequestModel model);
        Task<InteractionResponseModel> UpdateInteraction(int id, InteractionRequestModel model);
    }
}

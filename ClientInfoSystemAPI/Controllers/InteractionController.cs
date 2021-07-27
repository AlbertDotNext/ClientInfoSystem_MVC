using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionController : ControllerBase
    {
        private readonly IInteractionService _interactionService;

        public InteractionController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInteractions()
        {
            var interactions = await _interactionService.GetInteractions();
            if (!interactions.Any())
            {
                throw new NotFoundException("No interactions found");
            }

            return Ok(interactions);
        }

        [HttpPost]
        public async Task<IActionResult> AddInteraction([FromBody] InteractionRequestModel requestModel)
        {
            var interaction = await _interactionService.AddInteraction(requestModel);
            return Ok(interaction);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateInteraction(int id, [FromBody] InteractionRequestModel requestModel)
        {
            var interaction = await _interactionService.UpdateInteraction(id, requestModel);
            return Ok(interaction);
        }
    }
}

using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystemMVC.Controllers
{
    public class InteractionsController : Controller
    {
        private readonly IInteractionService _interactionService;

        public InteractionsController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        public async Task<IActionResult> InteractionsList()
        {
            var interactions = await _interactionService.GetInteractions();
            if (!interactions.Any())
            {
                throw new NotFoundException("No interactions found");
            }
            return View(interactions);
        }
        [HttpGet]
        public IActionResult AddInteraction()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddInteraction(InteractionRequestModel requestModel)
        {
            await _interactionService.AddInteraction(requestModel);
            return RedirectToAction("InteractionsList");
        }
    }
}

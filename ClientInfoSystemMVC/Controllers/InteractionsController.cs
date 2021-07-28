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

        [HttpGet]
        public IActionResult UpdateInteraction()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateInteraction(int id, InteractionRequestModel requestModel)
        {
            await _interactionService.UpdateInteraction(id, requestModel);
            return RedirectToAction("InteractionsList");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteInteraction(int id)
        {
            await _interactionService.DeleteInteraction(id);
            return RedirectToAction("InteractionsList");
        }

        [HttpGet]
        public async Task<IActionResult> InteractionWithClient(int id)
        {
            var interactions = await _interactionService.GetClientInteractionsById(id);
            if (!interactions.Any())
            {
                return View("_NotFound", "Shared");
            }
            return View(interactions);
        }

        [HttpGet]
        public async Task<IActionResult> InteractionWithEmployee(int id)
        {
            var interactions = await _interactionService.GetEmployeeInteractionsById(id);
            if (!interactions.Any())
            {
                return View("_NotFound", "Shared");
            }
            return View(interactions);
        }
    }
}

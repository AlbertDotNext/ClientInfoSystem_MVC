using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientInfoSystemMVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> ClientList()
        {
            var clients = await _clientService.GetAllClients();
            return View(clients);
        }
        [HttpGet]
        public IActionResult UpdateClient(int id)
        {
            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateClient(ClientRequestModel clientRequest)
        {
            await _clientService.UpdateClientById(clientRequest);
            return RedirectToAction("ClientList");
        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient(ClientRequestModel clientRequest)
        {
            if (!ModelState.IsValid) return View();
            var client = await _clientService.AddClient(clientRequest);
            return RedirectToAction("ClientList");
        }

        [HttpGet]
        public IActionResult DeleteClient()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientById(id);
            return RedirectToAction("ClientList");
        }
    }
}

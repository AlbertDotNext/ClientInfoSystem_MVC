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
        public async Task<IActionResult> UpdateClient(int id)
        {
            await _clientService.GetClientById(id);
            return View();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClient([FromBody] ClientRequestModel clientRequest)
        {
            await _clientService.UpdateClientById(clientRequest);
            return View();
        }

        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] ClientRequestModel clientRequest)
        {
            var client = await _clientService.AddClient(clientRequest);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientService.DeleteClientById(id);
            return LocalRedirect("~/");
        }
    }
}

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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            if (!clients.Any())
            {
                return NotFound("No Clients Found");
            }
            return Ok(clients);
        }

        [HttpPut]
        [Route("client")]
        public async Task<ActionResult> UpdateClient([FromBody] ClientRequestModel clientRequest)
        {
            await _clientService.UpdateClientById(clientRequest);
            return Ok();
        }
    }
}

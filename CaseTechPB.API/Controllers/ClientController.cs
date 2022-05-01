using CaseTechPB.Core.Entities;
using CaseTechPB.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CaseTechPB.Api.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        [Route("{email}")]
        [ProducesResponseType(typeof(ClientEntitie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string email, CancellationToken ctx)
        {
            var client = await _clientService.GetClient(email, ctx);

            if (client is null)
            {
                return NotFound("Client not found");
            }

            return Ok(client);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClientEntitie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetList(CancellationToken ctx)
        {
            var clients = await _clientService.GetAllClientAsync(ctx);

            if (clients is null)
            {
                return NotFound("Could not found any clients");
            }

            return Ok(clients);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientEntitie), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ClientEntitie client, CancellationToken ctx)
        {
            var result = await _clientService.InsertClientAsync(client, ctx);

            if (result)
            {
                return Created($"client/{client.Email}", client);
            }

            return BadRequest("Data is not Valid - Or email is already registered");
        }

        [HttpPut]
        [Route("{email}")]
        [ProducesResponseType(typeof(ClientEntitie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] ClientEntitie client, string email, CancellationToken ctx)
        {
            var result = await _clientService.UpdateClientAsync(client, email, ctx);

            if (result)
            {
                return Ok("Update successfully");
            }

            return BadRequest("An error occured during update proccess");
        }

        [HttpDelete]
        [Route("{email}")]
        [ProducesResponseType(typeof(ClientEntitie), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(string email, CancellationToken ctx)
        {
            var result = await _clientService.DeleteClientAsync(email, ctx);

            if(result)
            {
                return NoContent();
            }

            return BadRequest("An error occured during delete proccess");
        }
    }
}

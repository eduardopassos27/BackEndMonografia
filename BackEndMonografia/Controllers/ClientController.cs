using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult<ClienteCompleteResponseDto>> GetByAccountNumber([FromRoute] int accountId)
        {
            var retorno = await _clientService.GetByAccountNumber(accountId);

            return Ok(retorno);
        }

        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<List<ClienteCompleteResponseDto>>> GetByAccountNumber([FromRoute] string name)
        {
            var retorno = await _clientService.GetByName(name);

            return Ok(retorno.ToList());
        }

        [HttpGet("document/{documentoNumber}")]
        public async Task<ActionResult<List<ClienteCompleteResponseDto>>> GetByDocumentNumber([FromRoute] string documentoNumber)
        {
            var retorno = await _clientService.GetByDocumentNumber(documentoNumber);

            return Ok(retorno.ToList());
        }


    }
}

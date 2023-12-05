using BackEndMonografia.Models.System;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IBaseService<ClientModel> _baseService;
        private readonly IClientService _clientService;

        public ClientController(IBaseService<ClientModel> baseService, IClientService clientService)
        {
            _baseService = baseService;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> GetAllAreas()
        {
            var retorno = await _baseService.GetAll();

            return Ok(retorno.ToList());
        }
        [HttpPost]
        public async Task<ActionResult<int>> InsertArea([FromBody] ClientModel model)
        {
            var retorno = await _baseService.Add(model);

            return Ok(retorno);
        }
        [HttpGet("{accountId}")]
        public async Task<ActionResult<ClientModel>> GetByAccountNumber([FromRoute] int accountId)
        {
            var retorno = await _clientService.GetByAccountNumber(accountId);

            return Ok(retorno);
        }

        [HttpGet("by-name/{name}")]
        public async Task<ActionResult<List<ClientModel>>> GetByAccountNumber([FromRoute] string name)
        {
            var retorno = await _clientService.GetByName(name);

            return Ok(retorno.ToList());
        }

        [HttpGet("document/{documentoNumber}")]
        public async Task<ActionResult<List<ClientModel>>> GetByDocumentNumber([FromRoute] string documentoNumber)
        {
            var retorno = await _clientService.GetByDocumentNumber(documentoNumber);

            return Ok(retorno.ToList());
        }


    }
}

using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientService _clienteService;

        public ClientesController(IClientService clientService)
        {
            _clienteService = clientService;
        }

        [HttpGet("contas/{numeroConta}")]
        public async Task<ActionResult<ClienteCompleteResponseDto>> ObterPeloNumeroDaConta([FromRoute] int numeroConta)
        {
            var retorno = await _clienteService.ObterPeloNumeroDaConta(numeroConta);

            return Ok(retorno);
        }

        [HttpGet("nomes/{nomeCliente}")]
        public async Task<ActionResult<List<ClienteCompleteResponseDto>>> ObterPeloNomeDoCliente([FromRoute] string nomeCliente)
        {
            var retorno = await _clienteService.ObterPeloNomeDoCliente(nomeCliente);

            return Ok(retorno.ToList());
        }

        [HttpGet("documentos/{numeroDocumento}")]
        public async Task<ActionResult<List<ClienteCompleteResponseDto>>> ObterPeloNumeroDoDocumento([FromRoute] string numeroDocumento)
        {
            var retorno = await _clienteService.ObterPeloNumeroDoDocumento(numeroDocumento);

            return Ok(retorno.ToList());
        }


    }
}

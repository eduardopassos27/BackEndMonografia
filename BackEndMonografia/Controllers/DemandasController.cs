using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/demandas")]
    public class DemandasController : ControllerBase
    {
        private readonly IDemandService _demandaService;

        public DemandasController(IDemandService demandService)
        {
            _demandaService = demandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DemandModel>>> ObterTodas()
        {
            var retorno = await _demandaService.ObterTodas();

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<DemandModel>> Adicionar([FromBody] DemandModel model)
        {
            var retorno = await _demandaService.Adicionar(model);

            return Ok(retorno);
        }

        [HttpGet("clientes/{clienteId}")]
        public async Task<ActionResult<List<CompleteDemandModel>>> ObterDemandasPorCliente([FromRoute] int clienteId)
        {
            var retorno = await _demandaService.ObterDemandasPorClienteId(clienteId);

            return Ok(retorno);
        }
    }
}

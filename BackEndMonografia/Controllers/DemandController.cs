using BackEndMonografia.Models.System;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/demands")]
    public class DemandController : ControllerBase
    {
        private readonly IDemandService _demandService;

        public DemandController(IDemandService demandService)
        {
            _demandService = demandService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DemandModel>>> GetAll()
        {
            var retorno = await _demandService.GetAll();

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<DemandModel>> Add([FromBody] DemandModel model)
        {
            var retorno = await _demandService.Add(model);

            return Ok(retorno);
        }

        [HttpGet("by-client/{clientId}")]
        public async Task<ActionResult<List<CompleteDemandModel>>> GetDemandsByClient([FromRoute] int clientId)
        {
            var retorno = await _demandService.GetDemandsByClient(clientId);

            return Ok(retorno);
        }
    }
}

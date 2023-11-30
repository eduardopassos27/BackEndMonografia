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
            var retorno =  await _demandService.GetAll();

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<DemandModel>> Add([FromBody]DemandModel model)
        {
            var retorno = await _demandService.Add(model);

            return Ok(retorno);
        }
    }
}

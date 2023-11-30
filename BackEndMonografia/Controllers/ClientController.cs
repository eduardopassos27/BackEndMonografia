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

        public ClientController(IBaseService<ClientModel> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> GetAllAreas()
        {
            var retorno = await _baseService.GetAll();

            return Ok(retorno.ToList());
        }
        [HttpPost]
        public async Task<ActionResult<int>> InserArea([FromBody] ClientModel model)
        {
            var retorno = await _baseService.Add(model);

            return Ok(retorno);
        }
    }
}

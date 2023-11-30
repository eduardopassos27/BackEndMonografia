using BackEndMonografia.Models.System;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/status")]
    public class StatusController : ControllerBase
    {
        private readonly IBaseService<StatusModel> _baseService;

        public StatusController(IBaseService<StatusModel> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StatusModel>>> GetAllAreas()
        {
            var retorno = await _baseService.GetAll();

            return Ok(retorno.ToList());
        }
        [HttpPost]
        public async Task<ActionResult<int>> InserArea([FromBody] StatusModel model)
        {
            var retorno = await _baseService.Add(model);

            return Ok(retorno);
        }
    }
}

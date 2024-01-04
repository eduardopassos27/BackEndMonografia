using BackEndMonografia.Models;
using BackEndMonografia.Models.System;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/areas")]
    public class AreaController : ControllerBase
    {
        private readonly IBaseService<AreaDto> _baseService;

        public AreaController(IBaseService<AreaDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AreaDto>>> GetAllAreas()
        {
            var retorno = await _baseService.GetAll();

            return Ok(retorno.ToList());
        }
        [HttpPost]
        public async Task<ActionResult<int>> InserArea([FromBody] AreaDto model)
        {
            var retorno = await _baseService.Add(model);

            return Ok(retorno);
        }
    }
}

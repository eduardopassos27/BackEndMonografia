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
        private readonly IBaseService<AreaModel> _baseService;

        public AreaController(IBaseService<AreaModel> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AreaModel>>> GetAllAreas()
        {
            var retorno = await _baseService.GetAll();

            return Ok(retorno.ToList());
        }
        [HttpPost]
        public async Task<ActionResult<int>> InserArea([FromBody] AreaModel model)
        {
            var retorno = await _baseService.Add(model);

            return Ok(retorno);
        }
    }
}

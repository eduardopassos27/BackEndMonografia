using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/segments")]
    public class SegmentController : ControllerBase
    {
        private readonly IBaseService<SegmentoDto> _baseService;

        public SegmentController(IBaseService<SegmentoDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SegmentoDto>>> GetAll()
        {
            var retorno = await _baseService.GetAll();

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Insert([FromBody] SegmentoDto model)
        {
            var retorno = await _baseService.Add(model);

            return Ok(retorno);
        }
    }
}

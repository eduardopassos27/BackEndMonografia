using BackEndMonografia.Models.System;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/segments")]
    public class SegmentController : ControllerBase
    {
        private readonly IBaseService<SegmentModel> _baseService;

        public SegmentController(IBaseService<SegmentModel> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SegmentModel>>> GetAll()
        {
            var retorno = await _baseService.GetAll();

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Insert([FromBody] SegmentModel model)
        {
            var retorno = await _baseService.Add(model);

            return Ok(retorno);
        }
    }
}

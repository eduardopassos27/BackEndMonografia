using BackEndMonografia.Models.System;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/origin")]
    public class OriginController : ControllerBase
    {
        private readonly IBaseService<OriginModel> _baseService;

        public OriginController(IBaseService<OriginModel> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OriginModel>>> GetAll() 
        {
            var result = await _baseService.GetAll();

            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<OriginModel>>> InsertDescription(OriginModel model)
        {
            var result = await _baseService.Add(model);

            return Ok(result);
        }
    }
}

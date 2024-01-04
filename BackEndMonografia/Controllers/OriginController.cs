using BackEndMonografia.Dtos;
using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/origins")]
    public class OriginController : ControllerBase
    {
        private readonly IBaseService<OrigemDto> _baseService;

        public OriginController(IBaseService<OrigemDto> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrigemDto>>> GetAll() 
        {
            var result = await _baseService.GetAll();

            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<OrigemDto>>> InsertDescription(OrigemDto model)
        {
            var result = await _baseService.Add(model);

            return Ok(result);
        }
    }
}

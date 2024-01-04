using BackEndMonografia.Dtos;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/valor-campos-adicionais")]
    public class ValorCampoAdicionalController : ControllerBase
    {
        private readonly IValorCampoAdicionalService _valorCampoAdicionalService;

        public ValorCampoAdicionalController(IValorCampoAdicionalService valorCampoAdicionalService)
        {
            _valorCampoAdicionalService = valorCampoAdicionalService;
        }

        [HttpPost]
        public async Task<ActionResult> InsertAsync(List<ValorCampoAdicionalDto> dtos)
        {
            var result = await _valorCampoAdicionalService.InsertAsync(dtos);

            if(result)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

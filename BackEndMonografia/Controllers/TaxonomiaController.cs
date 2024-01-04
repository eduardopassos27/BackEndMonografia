using BackEndMonografia.Models;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/taxonomias")]
    public class TaxonomiaController : ControllerBase
    {
        private readonly ITaxonomyService _taxonomiaService;

        public TaxonomiaController(ITaxonomyService taxonomyService)
        {
            _taxonomiaService = taxonomyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaxonomyModel>>> ObterTodos() 
        {
            var result = await _taxonomiaService.ObterTodos();

            return Ok(result.ToList());
        }
        [HttpGet("origem/{origemId}")]
        public async Task<ActionResult<List<TaxonomyModel>>> ObterPorOrigem([FromRoute]int origemId)
        {
            var result = await _taxonomiaService.ObterPorOrigem(origemId);

            return Ok(result.ToList());
        }
        [HttpGet("origem/{origemId}/tipos/{typeId}")]
        public async Task<ActionResult<List<TaxonomyModel>>> ObterPorTipoIdEOrigemId([FromRoute] int origemId, [FromRoute] int typeId)
        {
            var result = await _taxonomiaService.ObterPorTipoIdEOrigemId(origemId, typeId);

            return Ok(result.ToList());
        }
        [HttpGet("origem/{origemId}/tipos/{typeId}/descricoes/{descriptionId}")]
        public async Task<ActionResult<List<TaxonomyModel>>> ObterPorTipoIdEOrigemIdEDescricaoId([FromRoute] int origemId,
                                                                                              [FromRoute] int typeId,
                                                                                              [FromRoute] int descriptionId)
        {
            var result = await _taxonomiaService.ObterPorTipoIdEOrigemIdEDescricaoId(origemId, typeId, descriptionId);

            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<TaxonomyModel>> Adicionar(TaxonomyModel model)
        {
            var result = await _taxonomiaService.Adicionar(model);

            return Ok(result);
        }
    }
}

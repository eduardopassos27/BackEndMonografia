using BackEndMonografia.Models.System;
using BackEndMonografia.Services;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/taxonomy")]
    public class TaxonomyController : ControllerBase
    {
        private readonly ITaxonomyService _taxonomyService;

        public TaxonomyController(ITaxonomyService taxonomyService)
        {
            _taxonomyService = taxonomyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaxonomyModel>>> GetAll() 
        {
            var result = await _taxonomyService.GetAll();

            return Ok(result.ToList());
        }
        [HttpGet("origem/{origemId}")]
        public async Task<ActionResult<List<TaxonomyModel>>> GetByOrigem([FromRoute]int origemId)
        {
            var result = await _taxonomyService.GetByOrigem(origemId);

            return Ok(result.ToList());
        }
        [HttpGet("origem/{origemId}/type/{typeId}")]
        public async Task<ActionResult<List<TaxonomyModel>>> GetByOrigemAndType([FromRoute] int origemId, [FromRoute] int typeId)
        {
            var result = await _taxonomyService.GetByOrigemAndType(origemId, typeId);

            return Ok(result.ToList());
        }
        [HttpGet("origem/{origemId}/type/{typeId}/description/{descriptionId}")]
        public async Task<ActionResult<List<TaxonomyModel>>> GetByOrigemAndTypeAndDescription([FromRoute] int origemId,
                                                                                              [FromRoute] int typeId,
                                                                                              [FromRoute] int descriptionId)
        {
            var result = await _taxonomyService.GetByOrigemAndTypeAndDescription(origemId, typeId, descriptionId);

            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<TaxonomyModel>> InsertDescription(TaxonomyModel model)
        {
            var result = await _taxonomyService.Add(model);

            return Ok(result);
        }
    }
}

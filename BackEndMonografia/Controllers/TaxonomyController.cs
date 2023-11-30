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

        [HttpPost]
        public async Task<ActionResult<TaxonomyModel>> InsertDescription(TaxonomyModel model)
        {
            var result = await _taxonomyService.Add(model);

            return Ok(result);
        }
    }
}

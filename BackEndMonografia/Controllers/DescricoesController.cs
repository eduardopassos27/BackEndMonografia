using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/descricoes")]
    public class DescricoesController : ControllerBase
    {
        private readonly IDescriptionService _descriptionService;

        public DescricoesController(IDescriptionService descriptionService)
        {
            _descriptionService = descriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DescriptionModel>>> ObterTodos() 
        {
            var result = await _descriptionService.ObterTodos();

            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<DescriptionModel>>> Adicionar(DescriptionModel model)
        {
            var result = await _descriptionService.Adicionar(model);

            return Ok(result);
        }

        [HttpGet("tipos/{tipoId}")]
        public async Task<ActionResult<List<DescriptionModel>>> ObterPorTipoId([FromRoute] int tipoId)
        {
            var result = await _descriptionService.ObterPorTipoId(tipoId);

            return Ok(result.ToList());
        }
    }
}

﻿using BackEndMonografia.Dtos;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/campos-adicionais")]
    public class CamposAdicionaisController : ControllerBase
    {
        public ICamposAdicionaisService _camposAdicionaiService;

        public CamposAdicionaisController(ICamposAdicionaisService camposAdicionaiService)
        {
            _camposAdicionaiService = camposAdicionaiService;
        }

        [HttpGet("origem/{idOrigem}/tipo/{tipoId}/descricao/{descricaoId}")]
        public async Task<ActionResult<List<CamposAdicionaisDto>>> ObterCamposAsync([FromRoute] int idOrigem,
                                                                              [FromRoute] int tipoId,
                                                                              [FromRoute] int descricaoId)
        {
            var retorno =  await _camposAdicionaiService.ObterCamposAsync(idOrigem, tipoId, descricaoId);

            return Ok(retorno.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<CamposAdicionaisDto>>> InsertCampoAdicionalAsync([FromBody] List<CamposAdicionaisDto> dtos)
        {
            var retorno = await _camposAdicionaiService.InsertCampoAdicionalAsync(dtos);

            return Ok(retorno);
        }


    }
}
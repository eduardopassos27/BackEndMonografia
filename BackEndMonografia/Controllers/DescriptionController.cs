using BackEndMonografia.Models;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/descriptions")]
    public class Description : ControllerBase
    {
        private readonly IDescriptionService _descriptionService;

        public Description(IDescriptionService descriptionService)
        {
            _descriptionService = descriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DescriptionModel>>> GetAll() 
        {
            var result = await _descriptionService.GetAllAsync();

            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<DescriptionModel>>> InsertDescription(DescriptionModel model)
        {
            var result = await _descriptionService.InsertAsync(model);

            return Ok(result);
        }

        [HttpGet("types/{typeId}")]
        public async Task<ActionResult<List<DescriptionModel>>> GetByTypeId([FromRoute] int typeId)
        {
            var result = await _descriptionService.GetByTypeId(typeId);

            return Ok(result.ToList());
        }
    }
}

using BackEndMonografia.Services;
using Microsoft.AspNetCore.Mvc;
using BackEndMonografia.Models.System;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/types")]
    public class TypeController : ControllerBase
    {
        public ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Type>>> GetAllTypes()
        {
            var retorno =  await _typeService.GetAllTypesAsync();

            return Ok(retorno.ToList());
        }
    }
}

using BackEndMonografia.Models.System;
using BackEndMonografia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndMonografia.Controllers
{
    [ApiController]
    [Route("v1/description")]
    public class Description : ControllerBase
    {
        private readonly IBaseService<DescriptionModel> _demandModel;

        public Description(IBaseService<DescriptionModel> demandModel)
        {
            _demandModel = demandModel;
        }

        [HttpGet]
        public async Task<ActionResult<List<DescriptionModel>>> GetAll() 
        {
            var result = await _demandModel.GetAll();

            return Ok(result.ToList());
        }

        [HttpPost]
        public async Task<ActionResult<List<DescriptionModel>>> InsertDescription(DescriptionModel model)
        {
            var result = await _demandModel.Add(model);

            return Ok(result);
        }
    }
}

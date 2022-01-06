using Data.Entities;
using FragranceShopApi.Extensions;
using FragranceShopApi.Models.Perfumer;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FragranceShopApi.Controllers
{
    [Route("api/perfumer")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PerfumerController : ControllerBase
    {
        private readonly IPerfumerService _perfumerService;

        public PerfumerController(IPerfumerService perfumerService)
        {
            _perfumerService = perfumerService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreatePerfumerDto dto)
        {
            var id = _perfumerService.Create(dto);

            return Created($"api/perfumer/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdatePerfumerDto dto, [FromRoute] int id)
        {
            _perfumerService.Update(dto, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _perfumerService.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<List<PerfumerDto>> GetAll([FromQuery] PerfumerQueryFilter filter, [FromQuery] PerfumerQueryPager pager)
        {
            var perfumersDto = _perfumerService.GetAll(filter, pager);
            
            return Ok(perfumersDto);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<PerfumerDto> Get([FromRoute] int id)
        {
            var perfumerDto = _perfumerService.GetById(id);

            if (perfumerDto is null)
            {
                return NotFound();
            }

            return Ok(perfumerDto);
        }
    }
}

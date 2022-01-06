using FragranceShopApi.Models;
using FragranceShopApi.Models.PerfumeBrand;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FragranceShopApi.Controllers
{
    [Route("api/perfumeBrand")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PerfumeBrandController : ControllerBase
    {
        private readonly IPerfumeBrandService _perfumeBrandService;

        public PerfumeBrandController(IPerfumeBrandService perfumeBrandService)
        {
            _perfumeBrandService = perfumeBrandService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreatePerfumeBrandDto dto)
        {
            var id = _perfumeBrandService.Create(dto);

            return Created($"api/perfumeBrand/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdatePerfumeBrandDto dto, [FromRoute] int id)
        {
            _perfumeBrandService.Update(dto, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _perfumeBrandService.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<PagedResult<PerfumeBrandDto>> GetAll([FromQuery] PerfumeBrandQueryFilter filter, [FromQuery] PerfumeBrandQueryPager pager)
        {
            var perfumeBrands = _perfumeBrandService.GetAll(filter, pager);

            return Ok(perfumeBrands);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<PerfumeBrandDto> Get([FromRoute] int id)
        {
            var perfumerDto = _perfumeBrandService.GetById(id);

            return Ok(perfumerDto);
        }
    }
}

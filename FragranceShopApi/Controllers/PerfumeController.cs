using FragranceShopApi.Extensions;
using FragranceShopApi.Models;
using FragranceShopApi.Models.FragranceNote;
using FragranceShopApi.Models.Perfume;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Controllers
{
    [ApiController]
    [Route("api/perfume")]
    [Authorize(Roles = "Admin, ProductsAdmin")]
    public class PerfumeController : ControllerBase
    {
        private readonly IPerfumeService _perfumeService;

        public PerfumeController(IPerfumeService perfumeService)
        {
            _perfumeService = perfumeService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreatePerfumeDto dto)
        {
            var id = _perfumeService.Create(dto);

            return Created($"api/perfume/{id}", null);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdatePerfumeDto dto, [FromRoute] int id)
        {
            _perfumeService.Update(dto, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _perfumeService.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<PagedResult<PerfumeDto>> GetAll([FromQuery] PerfumeQueryFilter filter, [FromQuery] PerfumeQueryPager pager)
        {
            var perfumes = _perfumeService.GetAll(filter, pager);

            return Ok(perfumes);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ResponseCache(Duration = 10 * 60)]
        public ActionResult<PerfumeDto> Get([FromRoute] int id)
        {
            var perfumerDto = _perfumeService.GetById(id);

            return Ok(perfumerDto);
        }

        [HttpGet("filtersOptions")]
        [AllowAnonymous]
        [ResponseCache(Duration = 20 * 60)]
        public ActionResult<FiltersOptions> GetFiltersOptions()
        {
            var filtersOptions = _perfumeService.GetFiltersOptions();

            return Ok(filtersOptions);
        }

        // Raczej do wywalenia
        [HttpGet("orderOptions")]
        [AllowAnonymous]
        [ResponseCache(Duration = 2 * 60 * 60)]
        public ActionResult<List<OrderOption>> GetOrderOptions()
        {
            var orderOptions = _perfumeService.GetOrderOptions();

            return Ok(orderOptions);
        }
    }
}

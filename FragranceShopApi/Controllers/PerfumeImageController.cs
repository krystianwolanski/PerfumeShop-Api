using FragranceShopApi.Models.PerfumeImage;
using FragranceShopApi.Models.PerfumeImg;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FragranceShopApi.Controllers
{
    [Route("api/perfume/{perfumeId}/image")]
    [ApiController]
    [Authorize(Roles = "Admin, ProductsAdmin")]
    public class PerfumeImageController : ControllerBase
    {
        private readonly IPerfumeImageService _perfumeImageService;

        public PerfumeImageController(IPerfumeImageService perfumeImageService)
        {
            _perfumeImageService = perfumeImageService;
        }

        [HttpPost]
        public async Task<ActionResult> AddRange([FromRoute] int perfumeId, [FromForm] List<CreatePerfumeImageDto> dtos)
        {
            await _perfumeImageService.AddRange(perfumeId, dtos);

            return Ok();
        }

        [HttpPut("{perfumeImageId}")]
        public ActionResult Update([FromRoute] int perfumeId, [FromRoute] int perfumeImageId, [FromBody] UpdatePerfumeImageDto dto)
        {
            _perfumeImageService.Update(perfumeId, perfumeImageId, dto);

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteAll([FromRoute] int perfumeId)
        {
            _perfumeImageService.DeleteAll(perfumeId);

            return NoContent();
        }

        [HttpDelete("{perfumeImageId}")]
        public ActionResult Delete([FromRoute] int perfumeId, [FromRoute] int perfumeImageId)
        {
            _perfumeImageService.Delete(perfumeId, perfumeImageId);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<PerfumeImageDto>> GetAll([FromRoute] int perfumeId)
        {
            var result = _perfumeImageService.GetAll(perfumeId);

            return Ok(result);
        }

        [HttpGet("{perfumeImageId}")]
        public ActionResult<PerfumeImageDto> Get([FromRoute] int perfumeId, [FromRoute] int perfumeImageId)
        {
            var perfumeImage = _perfumeImageService.GetById(perfumeId, perfumeImageId);

            return Ok(perfumeImage);
        }
    }
}

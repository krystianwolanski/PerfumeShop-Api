using FragranceShopApi.Models;
using FragranceShopApi.Models.PerfumeReview;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Controllers
{
    [Route("api/perfume/{perfumeId}/review")]
    [ApiController]
    public class PerfumeReviewController : ControllerBase
    {
        private readonly IPerfumeReviewService _perfumeReviewService;

        public PerfumeReviewController(IPerfumeReviewService perfumeReviewService)
        {
            _perfumeReviewService = perfumeReviewService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([FromRoute] int perfumeId, [FromBody] CreatePerfumeReviewDto dto)
        {
            var newPerfumeReviewId = _perfumeReviewService.Create(perfumeId, dto);

            return Created($"api/perfume/{perfumeId}/review/{newPerfumeReviewId}", null);
        }

        [HttpPut("{perfumeReviewId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update([FromRoute] int perfumeId, [FromRoute] int perfumeReviewId, [FromBody] UpdatePerfumeReviewDto dto)
        {
            _perfumeReviewService.Update(perfumeId, perfumeReviewId, dto);

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteAll([FromRoute] int perfumeId)
        {
            _perfumeReviewService.DeleteAll(perfumeId);

            return NoContent();
        }

        [HttpDelete("{perfumeReviewId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute] int perfumeId, [FromRoute] int perfumeReviewId)
        {
            _perfumeReviewService.Delete(perfumeId, perfumeReviewId);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<PagedResult<PerfumeReviewDto>> GetAll([FromRoute] int perfumeId, [FromQuery] PerfumeReviewQueryFilter filter, [FromQuery] PerfumeReviewQueryPager pager)
        {
            var perfumeReviews = _perfumeReviewService.GetAll(perfumeId, filter, pager);

            return Ok(perfumeReviews);
        }

        [HttpGet("{perfumeReviewId}")]
        public ActionResult<PerfumeReviewDto> Get([FromRoute] int perfumeId, [FromRoute] int perfumeReviewId)
        {
            var perfumeReview = _perfumeReviewService.GetById(perfumeId, perfumeReviewId);

            return Ok(perfumeReview);
        }

        [HttpPost("add")]
        [Authorize]
        public ActionResult Add([FromRoute] int perfumeId, [FromBody] AddPerfumeReviewDto dto)
        {
            var newPerfumeReviewId = _perfumeReviewService.Add(perfumeId, dto);

            return Created($"api/perfume/{perfumeId}/review/{newPerfumeReviewId}", null);
        }
    }
}

using FragranceShopApi.Models;
using FragranceShopApi.Models.FragranceNote;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FragranceShopApi.Controllers
{
    [Route("api/fragranceNote")]
    [ApiController]
    [Authorize(Roles="Admin")]
    public class FragranceNoteController : ControllerBase
    {
        private readonly IFragranceNoteService _fragranceNoteService;

        public FragranceNoteController(IFragranceNoteService fragranceNoteService)
        {
            _fragranceNoteService = fragranceNoteService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreateFragranceNoteDto dto)
        {
            var id = await _fragranceNoteService.Create(dto);

            return Created($"api/fragranceNote/{id}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromForm] UpdateFragranceNoteDto dto, [FromRoute] int id)
        {
            await _fragranceNoteService.Update(dto, id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _fragranceNoteService.Delete(id);

            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult<PagedResult<FragranceNoteDto>> GetAll([FromQuery] FragranceNoteQueryFilter filter, [FromQuery] FragranceNoteQueryPager pager)
        {
            var fragranceNotes = _fragranceNoteService.GetAll(filter, pager);

            return Ok(fragranceNotes);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<FragranceNoteDto> Get([FromRoute] int id)
        {
            var fragranceNoteDto = _fragranceNoteService.GetById(id);

            return Ok(fragranceNoteDto);
        }
    }
}

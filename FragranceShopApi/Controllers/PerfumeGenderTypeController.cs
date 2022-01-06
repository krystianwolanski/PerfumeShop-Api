using FragranceShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FragranceShopApi.Controllers
{
    [ApiController]
    [Route("api/perfumeGenderType")]
    public class PerfumeGenderTypeController : ControllerBase
    {
        private readonly IPerfumeGenderTypeService _perfumeGenderTypeService;

        public PerfumeGenderTypeController(IPerfumeGenderTypeService perfumeGenderTypeService)
        {
            _perfumeGenderTypeService = perfumeGenderTypeService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var genders = _perfumeGenderTypeService.GetAll();

            return Ok(genders);
        }
    }
}

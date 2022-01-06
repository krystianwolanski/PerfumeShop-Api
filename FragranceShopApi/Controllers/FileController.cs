using FragranceShopApi.Models.File;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FragranceShopApi.Controllers
{
    [Route("api/file")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public ActionResult Upload([FromForm] UploadFile model)
        {
            var directoryPath = $"{_env.WebRootPath}/{model.RelativePath}";
            if (!Directory.Exists(directoryPath))
            {
                return BadRequest("Entered directory doesn't exist");
            }

            var file = model.File;

            if (file != null && file.Length > 0)
            {
                var fileName = file.FileName;
                var fullPath = $"{directoryPath}/{fileName}";

                using (var stream = new FileStream(fullPath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok();
            }

            return BadRequest();
        }
    }
}

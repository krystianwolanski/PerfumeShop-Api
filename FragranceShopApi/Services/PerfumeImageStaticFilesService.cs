using FragranceShopApi.Services.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Services
{
    public interface IPerfumeImageStaticFilesService : IScopedService
    {
        void DeleteImages(params string[] relativePaths);
    }

    public sealed class PerfumeImageStaticFilesService : IPerfumeImageStaticFilesService
    {
        private readonly ILogger<PerfumeImageStaticFilesService> _logger;
        private readonly string _webRootPath;
        private readonly IStaticFilesService _staticFilesService;

        public PerfumeImageStaticFilesService(
            ILogger<PerfumeImageStaticFilesService> logger,
            IWebHostEnvironment appEnvironment,
            IStaticFilesService staticFilesService)
        {
            _logger = logger;
            _webRootPath = appEnvironment.WebRootPath;
            _staticFilesService = staticFilesService;
        }

        public void DeleteImages(params string[] relativePaths)
        {
            foreach (var relativePath in relativePaths)
            {
                var path = Path.Combine(_webRootPath, relativePath);

                try
                {
                    _staticFilesService.DeleteFile(path);
                }
                catch (FileNotFoundException)
                {
                    _logger.LogError($"File - {path} doesn't exists");
                }
            }
        }
    }
}

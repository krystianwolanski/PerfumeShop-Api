using Data.Entities;
using FragranceShopApi.Models.Image;
using FragranceShopApi.Models.PerfumeImg;
using FragranceShopApi.Services.Common;
using FragranceShopApi.Services.ImageProcess.FileSystem;
using Microsoft.AspNetCore.Hosting;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FragranceShopApi.Services.ImageProcess
{
    public interface IPerfumeImageProcessService : IScopedService
    {
        Task<List<PerfumeImg>> Process(string brandName, string perfumeName, List<CreatePerfumeImageDto> dtos);
    }
    public sealed class PerfumeImageProcessService : IPerfumeImageProcessService
    {
        private readonly string _webRootPath;
        private readonly IImageFileSystemProcessService _imageService;

        public PerfumeImageProcessService(
            IWebHostEnvironment appEnvironment,
            IImageFileSystemProcessService imageService)
        {
            _webRootPath = appEnvironment.WebRootPath;
            _imageService = imageService;
        }

        public async Task<List<PerfumeImg>> Process(string brandName, string perfumeName, List<CreatePerfumeImageDto> dtos)
        {
            const int ThumbnailWidth = 300;
            const int FullscreenWidth = 1000;

            var imageInputModels = dtos.Select(d => new ImageFileSystemInputModel
            {
                Content = d.Image.OpenReadStream(),
                FileName = Guid.NewGuid().ToString(),
                RelativePath = $"images/{brandName.Replace(' ','_')}/{perfumeName.Replace(' ','_')}"
            });

            var perfumeImgConcurrentBag = new ConcurrentBag<PerfumeImg>();

            await _imageService.Process(imageInputModels, async (image, index, imageResult) =>
            {
                var storagePath = Path.Combine(_webRootPath, image.RelativePath);

                if (!Directory.Exists(storagePath))
                {
                    Directory.CreateDirectory(storagePath);
                }

                var originalFileName = $"Original_{image.FileName}";
                var fullscreenFileName = $"Fullscreen_{image.FileName}";
                var thumbnailFileName = $"Thumbnail_{image.FileName}";

                List<Task> saveImagesTasks = new List<Task>
                {
                    _imageService.SaveAsJpegAsync(imageResult, originalFileName, storagePath),

                    Task.Run(() =>
                    {
                        var resizedImage = imageResult.Clone(i =>
                            i.Resize(new ResizeOptions
                            {
                                Mode = ResizeMode.Pad,
                                Size = new Size { Width = FullscreenWidth }
                            }));

                        return _imageService.SaveAsJpegAsync(resizedImage, fullscreenFileName, storagePath);
                    }),

                    Task.Run(() =>
                    {
                        var resizedImage = imageResult.Clone(i =>
                            i.Resize(new ResizeOptions
                            {
                                Mode = ResizeMode.Pad,
                                Size = new Size { Width = ThumbnailWidth }
                            }));

                        return _imageService.SaveAsJpegAsync(resizedImage, thumbnailFileName, storagePath);
                    })
                };

                await Task.WhenAll(saveImagesTasks);

                perfumeImgConcurrentBag.Add(new PerfumeImg
                {
                    IsPrimary = dtos.ElementAt(index).IsPrimary,
                    FullscreenImageUrl = $"{image.RelativePath}/{fullscreenFileName}.jpeg",
                    ThumbnailImageUrl = $"{image.RelativePath}/{thumbnailFileName}.jpeg",
                    OriginalImageUrl = $"{image.RelativePath}/{originalFileName}.jpeg"
                });
            });

            return perfumeImgConcurrentBag.ToList();
        }
    }
}

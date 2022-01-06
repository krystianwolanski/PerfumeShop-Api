using FragranceShopApi.Exceptions;
using FragranceShopApi.Models.FragranceNote;
using FragranceShopApi.Models.Image;
using FragranceShopApi.Services.Common;
using FragranceShopApi.Services.ImageProcess.MemoryStream;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Services.ImageProcess
{
    public interface IFragranceNoteImageProcessService : IScopedService
    {
        Task<byte[]> Process(IFormFile image);
    }

    public class FragranceNoteImageProcessService : IFragranceNoteImageProcessService
    {
        public readonly IImageMemoryStreamProcessService _imageService;

        public FragranceNoteImageProcessService(
            IImageMemoryStreamProcessService imageService)
        {
            _imageService = imageService;
        }

        public async Task<byte[]> Process(IFormFile image)
        {
            var imageInputModel = new ImageInputModel
            {
                Content = image.OpenReadStream()
            };

            var imgByteArray = await _imageService
                .Process(imageInputModel, async (image, imageResult) =>
                {
                    if (imageResult.Width != imageResult.Height)
                        throw new BadRequestException("The height and width of the image are not the same");

                    imageResult.Mutate(i => 
                        i.Resize(new Size(64,64)));

                    return await _imageService.SaveAsJpegAsync(imageResult);
                });

            return imgByteArray;
        }
    }
}

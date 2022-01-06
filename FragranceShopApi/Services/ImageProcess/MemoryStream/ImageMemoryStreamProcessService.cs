namespace FragranceShopApi.Services.ImageProcess.MemoryStream
{
    using FragranceShopApi.Models.Image;
    using FragranceShopApi.Services.Common;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats.Jpeg;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO;

    public interface IImageMemoryStreamProcessService : IBaseImageProcessService<ImageInputModel>, IScopedService
    {
        Task<byte[]> Process(ImageInputModel image, Func<ImageInputModel, Image, Task<byte[]>> action);
        Task<byte[]> SaveAsJpegAsync(Image image);
        Task<byte[]> SaveAsJpegAsync(Image image, int quality = 75);
    }
    public class ImageMemoryStreamProcessService : BaseImageProcessService<ImageInputModel>, IImageMemoryStreamProcessService
    {
        public async Task<byte[]> Process(ImageInputModel image, Func<ImageInputModel, Image, Task<byte[]>> action)
        {
            using var imageResult = await Image.LoadAsync(image.Content);

            return await action(image, imageResult);
        }

        public async Task<byte[]> SaveAsJpegAsync(Image image)
        {
            image.Metadata.ExifProfile = null;

            var memoryStream = new MemoryStream();

            await image.SaveAsJpegAsync(memoryStream);

            return memoryStream.ToArray();
        }

        public async Task<byte[]> SaveAsJpegAsync(Image image, int quality = 75)
        {
            image.Metadata.ExifProfile = null;

            var memoryStream = new MemoryStream();

            await image.SaveAsJpegAsync(memoryStream, new JpegEncoder
            {
                Quality = quality,
            });

            return memoryStream.ToArray();
        }
    }
}

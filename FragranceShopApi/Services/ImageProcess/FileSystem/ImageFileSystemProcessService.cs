namespace FragranceShopApi.Services.ImageProcess.FileSystem
{
    using FragranceShopApi.Models.Image;
    using FragranceShopApi.Services.Common;
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats.Jpeg;
    using System.Threading.Tasks;

    public interface IImageFileSystemProcessService : IBaseImageProcessService<ImageFileSystemInputModel>, IScopedService
    {
        Task SaveAsJpegAsync(Image image, string name, string path);
        Task SaveAsJpegAsync(Image image, string name, string path, int quality = 75);
    }

    public class ImageFileSystemProcessService : BaseImageProcessService<ImageFileSystemInputModel>, IImageFileSystemProcessService
    {
        public Task SaveAsJpegAsync(Image image, string name, string path)
        {
            image.Metadata.ExifProfile = null;

            return image.SaveAsJpegAsync($"{path}/{name}.jpeg");
        }

        public Task SaveAsJpegAsync(Image image, string name, string path, int quality = 75)
        {
            image.Metadata.ExifProfile = null;

            return image.SaveAsJpegAsync($"{path}/{name}.jpeg", new JpegEncoder
            {
                Quality = quality,
            });
        }
    }
}

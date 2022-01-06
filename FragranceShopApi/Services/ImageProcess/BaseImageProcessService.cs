using FragranceShopApi.Models.Image;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Services.ImageProcess
{
    public interface IBaseImageProcessService<T> where T : ImageInputModel
    {
        Task Process(IEnumerable<T> images, Func<T, int, Image, Task> action);
        Task Process(T image, Func<T, Image, Task> action);
    }

    public abstract class BaseImageProcessService<T> : IBaseImageProcessService<T> where T : ImageInputModel
    {
        public async Task Process(IEnumerable<T> images, Func<T, int, Image, Task> action)
        {
            var tasks = images
                .Select((image, index) => Task.Run(async () =>
                {
                    using var imageResult = await Image.LoadAsync(image.Content);

                    await action(image, index, imageResult);
                }));

            await Task.WhenAll(tasks);
        }

        public async Task Process(T image, Func<T, Image, Task> action)
        {
            using var imageResult = await Image.LoadAsync(image.Content);

            await action(image, imageResult);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Image
{
    public class ImageFileSystemInputModel : ImageInputModel
    {
        public string FileName { get; set; }

        public string RelativePath { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.File
{
    public class UploadFile
    {
        public IFormFile File { get; set; }
        public string RelativePath { get; set; }
    }
}

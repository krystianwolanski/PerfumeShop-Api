using FragranceShopApi.Models.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.PerfumeImg
{
    public class CreatePerfumeImageDto
    {
        public IFormFile Image { get; set; }
        public bool IsPrimary { get; set; }
    }
}

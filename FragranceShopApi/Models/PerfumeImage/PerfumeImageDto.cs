using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.PerfumeImg
{
    public class PerfumeImageDto
    {
        public string ThumbnailUrl { get; set; }
        public string FullscreenUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}

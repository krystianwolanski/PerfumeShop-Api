using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PerfumeImg
    {
        public int Id { get; set; }
        public string FullscreenImageUrl { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string OriginalImageUrl { get; set; }

        public int PerfumeId { get; set; }
        public Perfume Perfume { get; set; }
        public bool IsPrimary { get; set; }
    }
}

using FragranceShopApi.Models.PerfumeGenderType;
using FragranceShopApi.Models.PerfumeImg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Perfume
{
    public class PerfumeInOrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal BasePrice { get; set; }
        public string PerfumeBrandName { get; set; }
        public int Capacity { get; set; }
        public string PerfumeGenderType { get; set; }
        public string PerfumeImageUrl { get; set; }
    }
}

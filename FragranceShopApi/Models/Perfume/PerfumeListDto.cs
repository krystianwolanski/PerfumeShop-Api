using Data.Models;
using FragranceShopApi.Models.FragranceNote;
using FragranceShopApi.Models.PerfumeBrand;
using FragranceShopApi.Models.PerfumeGenderType;
using FragranceShopApi.Models.PerfumeImg;
using FragranceShopApi.Models.Perfumer;
using System.Collections.Generic;

namespace FragranceShopApi.Models.Perfume
{
    public class PerfumeListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal BasePrice { get; set; }
        public int Quantity { get; set; }
        public PerfumeBrandDto Brand { get; set; }
        public PerfumerDto Perfumer { get; set; }
        public int Capacity { get; set; }
        public PerfumeGenderTypeId GenderTypeId { get; set; }
        public IEnumerable<PerfumeImageDto> Images { get; set; }
    }
}

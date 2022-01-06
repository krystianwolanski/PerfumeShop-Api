using Data.Models;
using FragranceShopApi.Models.FragranceNote;
using FragranceShopApi.Models.PerfumeGenderType;
using FragranceShopApi.Models.PerfumeImg;
using System.Collections.Generic;

namespace FragranceShopApi.Models.Perfume
{
    public class PerfumeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal BasePrice { get; set; }
        public int Quantity { get; set; }
        public string PerfumerName { get; set; }
        public string PerfumeBrandName { get; set; }
        public int Capacity { get; set; }
        public PerfumeGenderTypeId PerfumeGenderTypeId { get; set; }
        public IEnumerable<PerfumeImageDto> Images { get; set; }
        public IEnumerable<FragranceNotePerfumeDto> FragranceNotePerfumeDtos { get; set; }
    }
}

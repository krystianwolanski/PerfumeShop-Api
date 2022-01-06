using Data.Models;
using FragranceShopApi.Models.PerfumeGenderType;
using FragranceShopApi.Models.PerfumeImage;
using FragranceShopApi.Models.PerfumeImg;
using System.Collections.Generic;

namespace FragranceShopApi.Models.Perfume
{
    public class UpdatePerfumeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal BasePrice { get; set; }
        public int Quantity { get; set; }
        public int PerfumerId { get; set; }
        public int PerfumeBrandId { get; set; }
        public int Capacity { get; set; }
        public PerfumeGenderTypeId PerfumeGenderTypeId { get; set; }
        public List<UpdateFragranceNotePerfumConnection> FragranceNotePerfumConnection { get; set; }

    }
}

using FragranceShopApi.Models.FragranceNote;
using FragranceShopApi.Models.PerfumeBrand;
using FragranceShopApi.Models.PerfumeGenderType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Perfume
{
    public class FiltersOptions
    {
        public List<PerfumeBrandDto> Brands { get; set; }
        public List<FragranceNoteDto> FragranceNotes { get; set; }
        public List<PerfumeGenderTypeDto> PerfumeGenderTypes { get; set; }
        public int[] Capacities { get; set; }
    }
}

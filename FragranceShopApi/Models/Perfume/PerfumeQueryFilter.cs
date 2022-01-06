using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Perfume
{
    public class PerfumeQueryFilter
    {
        public string Name { get; set; }
        public decimal? MinimumPrice { get; set; }
        public decimal? MaximumPrice { get; set; }
        //public string[] PerfumeGendersNames { get; set; }
        public PerfumeGenderTypeId[] PerfumeGenderTypeIds { get; set; }
        public int[] Capacities { get; set; }
        public string[] PerfumeBrandsNames { get; set; }
        public string[] FragranceNotesNames { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Perfume
{
    public class OrderOption
    {
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
        public string Display { get; set; }
    }
}

using FragranceShopApi.Models.Perfume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.OrderElement
{
    public class OrderElementDto
    {
        public int Id { get; set; }
        public PerfumeInOrderDto Perfume { get; set; }
        public int Quantity { get; set; }
    }
}

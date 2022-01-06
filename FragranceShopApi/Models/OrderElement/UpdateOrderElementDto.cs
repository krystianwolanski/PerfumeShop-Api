using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.OrderElement
{
    public class UpdateOrderElementDto
    {
        public int PerfumeId { get; set; }
        public int Quantity { get; set; }
    }
}

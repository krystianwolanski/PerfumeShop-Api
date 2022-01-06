using FragranceShopApi.Models.OrderElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Order
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public List<CreateOrderElementDto> CreateOrderElementDtos { get; set; }
    }
}

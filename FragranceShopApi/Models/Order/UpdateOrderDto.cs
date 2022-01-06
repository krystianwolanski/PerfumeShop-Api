using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Order
{
    public class UpdateOrderDto
    {
        public int CustomerId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public OrderStatusId OrderStatusId { get; set; }
        
    }
}

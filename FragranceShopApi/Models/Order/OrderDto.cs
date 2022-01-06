using Data.Models;
using FragranceShopApi.Models.Account;
using FragranceShopApi.Models.OrderElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public UserDto CreatedBy { get; set; }
        public UserDto Customer { get; set; }
        public OrderStatusId OrderStatusId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public List<OrderElementDto> OrderElements { get; set; }
    }
}

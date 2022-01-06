using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderStatus
    {
        public OrderStatusId Id { get; set; }
        public string Name { get; set; }
    }
}

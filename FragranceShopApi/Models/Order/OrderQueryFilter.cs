using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Order
{
    public class OrderQueryFilter
    {
        public int? CustomerId { get; set; }
        public DateTime? CompletedDateFrom { get; set; }
        public DateTime? CompletedDateTo { get; set; }
        public OrderStatusId? OrderStatusId { get; set; }
        public DateTime? DateCreatedFrom { get; set; }
        public DateTime? DateCreatedTo { get; set; }
        public int? CreatedById { get; set; }
    }
}

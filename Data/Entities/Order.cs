using Data.Models;
using Data.Models.EntityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : Auditable
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual User Customer { get; set; }
        public OrderStatusId OrderStatusId { get; set; }
        public DateTime? CompletedDate { get; set; }

        public virtual List<OrderElement> OrderElements { get; set; }
    }
}

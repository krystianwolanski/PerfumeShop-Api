using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderElement
    {
        public int Id { get; set; }
        public int PerfumeId { get; set; }
        public Perfume Perfume { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}

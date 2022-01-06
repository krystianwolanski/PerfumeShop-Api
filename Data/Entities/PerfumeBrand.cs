using Data.Models.EntityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PerfumeBrand : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Perfume> Perfumes { get; set; }
    }
}

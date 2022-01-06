using Data.Models;
using System.Collections.Generic;

namespace Data.Entities
{
    public class PerfumeGenderType
    {
        public PerfumeGenderTypeId Id { get; set; }
        public string Name { get; set; }

        public virtual List<Perfume> Perfumes { get; set; }
    }
}

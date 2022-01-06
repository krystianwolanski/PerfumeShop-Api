using Data.Models.EntityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PerfumeReview : Auditable
    {
        public int Id { get; set; }
        public int PerfumeId { get; set; }
        public int AuthorId { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }

        public virtual User Author { get; set; }
        public virtual Perfume Perfume { get; set; }
    }
}

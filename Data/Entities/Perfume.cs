using Data.Models;
using Data.Models.EntityHelpers;
using System.Collections.Generic;

namespace Data.Entities
{
    public class Perfume : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal BasePrice { get; set; }
        public int Quantity { get; set; }
        public int Capacity { get; set; }
        public PerfumeGenderTypeId PerfumeGenderTypeId { get; set; }
        public virtual PerfumeGenderType PerfumeGenderType { get; set; }

        public int PerfumerId { get; set; }
        public virtual Perfumer Perfumer { get; set; }

        public int PerfumeBrandId { get; set; }
        public virtual PerfumeBrand PerfumeBrand { get; set; }

        public virtual List<FragranceNotePerfume> FragranceNotesPerfumes { get; set; }

        public virtual List<PerfumeImg> PerfumeImgs { get; set; }
        public virtual List<PerfumeReview> PerfumeReviews { get; set; }
        public virtual List<OrderElement> OrderElements { get; set; }
    }
}

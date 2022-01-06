using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.PerfumeReview
{
    public class PerfumeReviewQueryFilter
    {
        public int? RatingFrom { get; set; }
        public int? RatingTo { get; set; }
        public string Review { get; set; }
        public int? AuthorId { get; set; }
    }
}

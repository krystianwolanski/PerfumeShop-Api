using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.PerfumeReview
{
    public class CreatePerfumeReviewDto
    {
        public string Review { get; set; }
        public int Rating { get;set; }
        public int AuthorId { get; set; }
    }
}

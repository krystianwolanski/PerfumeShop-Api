using FragranceShopApi.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.PerfumeReview
{
    public class PerfumeReviewDto
    {
        public int Id { get; set; }
        public UserDto AuthorDto { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
    }
}

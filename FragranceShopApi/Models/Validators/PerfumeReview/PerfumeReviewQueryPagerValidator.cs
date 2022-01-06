namespace FragranceShopApi.Models.Validators.PerfumeReview
{
    using FragranceShopApi.Models.PerfumeReview;
    using Data.Entities;

    public class PerfumeReviewQueryPagerValidator : DefaultPagerQueryValidator<PerfumeReviewQueryPager>
    {
        protected override string[] AllowedSortByColumnNames => 
            new[] { nameof(PerfumeReview.Rating) };
    }
}

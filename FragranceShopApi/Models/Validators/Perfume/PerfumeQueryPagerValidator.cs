namespace FragranceShopApi.Models.Validators.Perfume
{
    using FragranceShopApi.Models.Perfume;
    using Data.Entities;

    public class PerfumeQueryPagerValidator : DefaultPagerQueryValidator<PerfumeQueryPager>
    {
        protected override string[] AllowedSortByColumnNames => 
            new[] { nameof(Perfume.Name), nameof(Perfume.CurrentPrice) };
    }
}

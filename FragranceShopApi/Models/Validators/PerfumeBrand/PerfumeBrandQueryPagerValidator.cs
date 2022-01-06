namespace FragranceShopApi.Models.Validators.PerfumeBrand
{
    using FragranceShopApi.Models.PerfumeBrand;
    using Data.Entities;

    public class PerfumeBrandQueryPagerValidator : DefaultPagerQueryValidator<PerfumeBrandQueryPager>
    {
        protected override string[] AllowedSortByColumnNames => 
            new[] { nameof(PerfumeBrand.Name) };
    }
}

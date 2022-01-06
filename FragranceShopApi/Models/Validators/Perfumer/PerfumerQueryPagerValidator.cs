namespace FragranceShopApi.Models.Validators.Perfumer
{
    using FragranceShopApi.Models.Perfumer;
    using Data.Entities;

    public class PerfumerQueryPagerValidator : DefaultPagerQueryValidator<PerfumerQueryPager>
    {
        protected override string[] AllowedSortByColumnNames => 
            new[] { nameof(Perfumer.Name) };
    }
}

namespace FragranceShopApi.Models.Validators.FragranceNote
{
    using FragranceShopApi.Models.FragranceNote;
    using Data.Entities;

    public class FragranceNoteQueryPagerValidator : DefaultPagerQueryValidator<FragranceNoteQueryPager>
    {
        protected override string[] AllowedSortByColumnNames => 
            new[] { nameof(FragranceNote.Name) };
    }
}

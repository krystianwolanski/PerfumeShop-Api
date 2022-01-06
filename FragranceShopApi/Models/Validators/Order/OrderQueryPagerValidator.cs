namespace FragranceShopApi.Models.Validators.Order
{
    using Data.Entities;
    using FragranceShopApi.Models.Order;

    public class OrderQueryPagerValidator : DefaultPagerQueryValidator<OrderQueryPager>
    {
        protected override string[] AllowedSortByColumnNames => new[]
        {
            nameof(Order.DateCreated),
            nameof(Order.OrderStatusId),
            nameof(Order.CustomerId),
            nameof(Order.CompletedDate)
        };
    }
}

using FluentValidation;
using FragranceShopApi.Models.Perfume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Validators.Perfume
{
    public class PerfumeQueryFilterValidator : AbstractValidator<PerfumeQueryFilter>
    {
        public PerfumeQueryFilterValidator()
        {
            RuleFor(p => p.MinimumPrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.MaximumPrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.MinimumPrice)
                .Custom((minimumPrice, context) =>
                {
                    var maximumPrice = context.InstanceToValidate.MaximumPrice;
                    if (minimumPrice > maximumPrice)
                    {
                        context.AddFailure("MinimumPrice", "MinimumPrice can't be greater than MaximumPrice");
                    }
                });
        }
    }
}

using FluentValidation;
using FragranceShopApi.Models.PerfumeReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Validators.PerfumeReview
{
    public class PerfumeReviewQueryFilterValidator : AbstractValidator<PerfumeReviewQueryFilter>
    {
        public PerfumeReviewQueryFilterValidator()
        {
            RuleFor(f => f.RatingFrom)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(10);

            RuleFor(f => f.RatingTo)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(10);

            RuleFor(f => f.RatingFrom)
                .Custom((ratingFrom, context) =>
                {
                    var ratingTo = context.InstanceToValidate.RatingTo;

                    if (ratingFrom > ratingTo)
                        context.AddFailure("RatingFrom", "RatingFrom can't be greater than RatingTo");
                });
        }
    }
}

using FluentValidation;
using FragranceShopApi.Models.PerfumeReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Validators.PerfumeReview
{
    public class UpdatePerfumeReviewDtoValidator : AbstractValidator<UpdatePerfumeReviewDto>
    {
        public UpdatePerfumeReviewDtoValidator()
        {
            RuleFor(r => r.Rating)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(10);

            RuleFor(r => r.Review)
                .MaximumLength(6000);
        }
    }
}

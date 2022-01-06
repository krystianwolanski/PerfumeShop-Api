using FluentValidation;
using FragranceShopApi.Models.Perfume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Validators.Perfume
{
    public class CreatePerfumeDtoValidator : AbstractValidator<CreatePerfumeDto>
    {
        public CreatePerfumeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.BasePrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.CurrentPrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0);

            RuleFor(p => p.Capacity)
                .GreaterThan(0);
        }
    }
}

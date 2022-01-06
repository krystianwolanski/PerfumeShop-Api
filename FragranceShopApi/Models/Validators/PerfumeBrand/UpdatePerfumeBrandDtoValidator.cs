using FluentValidation;
using Data;
using FragranceShopApi.Models.PerfumeBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Validators.PerfumeBrand
{
    public class UpdatePerfumeBrandDtoValidator : AbstractValidator<UpdatePerfumeBrandDto>
    {
        public UpdatePerfumeBrandDtoValidator(PerfumeDbContext dbContext)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.Name)
                .Custom((value, context) =>
                {
                    var nameExists = dbContext.PerfumeBrands.Any(p => p.Name == value);

                    if (nameExists)
                    {
                        context.AddFailure("Name", "That brand is already added");
                    }
                });
        }
    }
}

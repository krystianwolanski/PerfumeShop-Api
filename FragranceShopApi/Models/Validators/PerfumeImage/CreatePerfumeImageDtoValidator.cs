using FluentValidation;
using FragranceShopApi.Extensions;
using FragranceShopApi.Models.PerfumeImg;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace FragranceShopApi.Models.Validators.PerfumeImage
{
    public class CreatePerfumeImageListDtoValidator : AbstractValidator<List<CreatePerfumeImageDto>>
    {
        public CreatePerfumeImageListDtoValidator()
        {
            RuleFor(p => p)
                .Custom((value, context) =>
                {
                    if (value.IsNullOrEmpty())
                    {
                        context.AddFailure("Image", "List can't be empty");
                    }
                    else if (value.Where(p => p.IsPrimary).Count() > 1)
                    {
                        context.AddFailure("IsPrimary", "You can't upload more than 1 primary images");
                    }
                });
        }
    }
}

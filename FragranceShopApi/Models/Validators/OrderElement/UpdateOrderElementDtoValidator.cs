using FluentValidation;
using Data;
using FragranceShopApi.Models.OrderElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Validators.OrderElement
{
    public class UpdateOrderElementDtoValidator : AbstractValidator<UpdateOrderElementDto>
    {
        public UpdateOrderElementDtoValidator(PerfumeDbContext dbContext)
        {
            RuleFor(o => o.Quantity)
                .Custom((quantity, context) =>
                {
                    var perfumeId = context.InstanceToValidate.PerfumeId;

                    var perfume = dbContext.Perfumes
                        .Where(p => p.Id == perfumeId)
                        .Select(p => new
                        {
                            Quantity = p.Quantity
                        })
                        .FirstOrDefault();

                    if (perfume is null)
                        context.AddFailure("PerfumeId", "Perfume doesn't exist");
                    else if (perfume.Quantity < quantity)
                        context.AddFailure("Quantity", "There is no such quantity of product");
                });
        }
    }
}

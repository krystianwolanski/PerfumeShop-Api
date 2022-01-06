using FluentValidation;
using Data;
using FragranceShopApi.Models.Perfumer;
using System.Linq;

namespace FragranceShopApi.Models.Validators.Perfumer
{
    public class UpdatePerfumerDtoValidator : AbstractValidator<UpdatePerfumerDto>
    {
        public UpdatePerfumerDtoValidator(PerfumeDbContext dbContext)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(40);

            RuleFor(p => p.Name)
                .Custom((value, context) =>
                {
                    var nameExists = dbContext.Perfumers.Any(p => p.Name == value);

                    if (nameExists)
                    {
                        context.AddFailure("Name", "That perfumer is already added");
                    }
                });
        }
    }
}

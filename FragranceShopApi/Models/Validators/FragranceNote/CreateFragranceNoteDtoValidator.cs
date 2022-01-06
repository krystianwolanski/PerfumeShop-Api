using FluentValidation;
using Data;
using FragranceShopApi.Models.FragranceNote;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace FragranceShopApi.Models.Validators.FragranceNote
{
    public class CreateFragranceNoteDtoValidator : AbstractValidator<CreateFragranceNoteDto>
    {
        public CreateFragranceNoteDtoValidator(PerfumeDbContext dbContext)
        {

            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.Name)
                .Custom((value, context) =>
                {
                    var nameExists = dbContext.FragranceNotes.Any(p => p.Name == value);

                    if (nameExists)
                    {
                        context.AddFailure("Name", "That fragrance note is already added");
                    }
                });
        }
    }
}

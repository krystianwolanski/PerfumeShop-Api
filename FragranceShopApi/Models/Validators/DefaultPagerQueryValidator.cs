using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.Validators
{
    /// <summary>
    /// Validate by rules: PageNumber, PageSize, SortBy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DefaultPagerQueryValidator<T> : AbstractValidator<T> where T : Pager
    {
        public DefaultPagerQueryValidator()
        {
            RuleFor(q => q.PageNumber).GreaterThanOrEqualTo(1);
            RuleForPageSize(AllowedPageSizes);
            RuleForSortBy(AllowedSortByColumnNames);
        }

        protected virtual int[] AllowedPageSizes => new[] { 5, 10, 15 };

        protected abstract string[] AllowedSortByColumnNames { get; }

        private void RuleForPageSize(int[] allowedPageSizes)
        {
            RuleFor(q => q.PageSize).Must(x => allowedPageSizes.Contains(x))
                    .WithMessage($"PageSize must be in [{ string.Join(",", allowedPageSizes)}]");
        }

        private void RuleForSortBy(string[] allowedSortByColumnNames)
        {
            RuleFor(q => q.SortBy).Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}

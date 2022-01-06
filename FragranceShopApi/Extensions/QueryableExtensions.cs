using FragranceShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FragranceShopApi.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, Pager pager)
        {
            query = query
                .OrderByPager(pager.SortBy, pager.SortDirection)
                .SkipAndTakeByPager(pager.PageSize, pager.PageNumber);

            return query;
        }

        public static IQueryable<T> OrderByPager<T>(this IQueryable<T> query, string sortBy, SortDirection sortDirection)
        {
            if (string.IsNullOrEmpty(sortBy)) return query;
   
            var source = Expression.Parameter(typeof(T));
            var memberExpression = Expression.Property(source, typeof(T).GetProperty(sortBy));
            var lambda = Expression.Lambda<Func<T, object>>(memberExpression, source);

            query = sortDirection == SortDirection.ASC ?
                query.OrderBy(lambda) :
                query.OrderByDescending(lambda);

            return query;
        }

        public static IQueryable<T> SkipAndTakeByPager<T>(this IQueryable<T> query, int pageSize, int pageNumber)
        {
            query = query
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);

            return query;
        }
    }
}

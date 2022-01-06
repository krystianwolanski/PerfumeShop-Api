using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Extensions
{
    public static class StaticFileResponseContextExtensions
    {
        public static void UseCacheForStaticFiles(this StaticFileResponseContext preparation, int days)
        {
            var headers = preparation.Context.Response.GetTypedHeaders();

            headers.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromDays(days)
            };

            headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(days));
        }
    }
}

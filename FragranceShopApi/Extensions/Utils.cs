using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace FragranceShopApi.Extensions
{
    public static class Utils
    {
        /// <summary>Indicates whether the specified array is null or has a length of zero.</summary>
        /// <param name="array">The array to test.</param>
        /// <returns>true if the array parameter is null or has a length of zero; otherwise, false.</returns>
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            return (array is null || array.Length == 0);
        }

        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return (list is null || list.Count == 0);
        }
    }
}

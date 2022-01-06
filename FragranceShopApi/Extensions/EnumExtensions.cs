using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions
{
    static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            var description = enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<DescriptionAttribute>()?
                .Description;

            if (string.IsNullOrEmpty(description))
                return enumValue.ToString();

            return description;
        }
    }
}

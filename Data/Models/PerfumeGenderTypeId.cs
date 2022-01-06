using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public enum PerfumeGenderTypeId : int
    {
        [Description("Męski")]
        ForMen = 1,

        [Description("Damski")]
        ForWomen = 2,

        [Description("Unisex")]
        Unisex = 3
    }
}

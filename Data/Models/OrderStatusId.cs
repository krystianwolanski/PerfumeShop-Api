using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public enum OrderStatusId : int
    {
        [Description("Oczekujące")]
        Pending = 1,

        [Description("W przygotowaniu")]
        Preparing = 2,

        [Description("Wysłane")]
        Shipped = 3,
       
        [Description("Odebrane")]
        Received = 4,

        [Description("Anulowane")]
        Cancelled = 5,
    }
}

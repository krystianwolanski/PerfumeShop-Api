using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models
{
    public class UpdateFragranceNotePerfumConnection
    {
        public int FragranceNoteId { get; set; }
        public FragranceNoteTypeId FragranceNoteTypeId { get; set; }
    }
}

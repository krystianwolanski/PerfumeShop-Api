using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FragranceNoteType
    {
        public FragranceNoteTypeId FragranceNoteTypeId { get; set; }
        public string Name { get; set; }

        public virtual List<FragranceNotePerfume> FragranceNotePerfumes { get; set; }
    }
}

using Data.Models.EntityHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FragranceNote : Auditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public virtual List<FragranceNotePerfume> FragranceNotesPerfumes { get; set; }

    }
}

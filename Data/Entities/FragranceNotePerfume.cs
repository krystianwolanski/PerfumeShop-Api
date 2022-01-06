using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FragranceNotePerfume
    {
        public int Id { get; set; }
        public FragranceNoteTypeId FragranceNoteTypeId { get; set; }
        public virtual FragranceNoteType FragranceNoteType { get; set; }

        public int PerfumeId { get; set; }
        public virtual Perfume Perfume { get; set; }

        public int FragranceNoteId { get; set; }
        public virtual FragranceNote FragranceNote { get; set; }
    }
}

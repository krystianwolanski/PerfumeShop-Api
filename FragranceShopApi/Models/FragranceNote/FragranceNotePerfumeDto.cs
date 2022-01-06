using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.FragranceNote
{
    public class FragranceNotePerfumeDto
    {
        public string Name { get; set; }
        public FragranceNoteTypeId FragranceNoteTypeId { get; set; }
        public byte[] Image { get; set; }
    }
}

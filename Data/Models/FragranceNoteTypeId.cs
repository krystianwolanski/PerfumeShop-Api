using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public enum FragranceNoteTypeId : int
    {
        [Description("Nuty głowy")]
        TopNote = 1,

        [Description("Nuty serca")]
        MiddleNote = 2,

        [Description("Nuty bazy")]
        BaseNote = 3
    }
}

using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.EntityHelpers
{
    public abstract class Auditable
    {
        public int CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }
        
        public int? LastModifiedById { get; set; }
        public virtual User LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}

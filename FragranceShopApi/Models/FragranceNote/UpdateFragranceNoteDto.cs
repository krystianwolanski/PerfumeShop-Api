using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Models.FragranceNote
{
    public class UpdateFragranceNoteDto
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
    }
}

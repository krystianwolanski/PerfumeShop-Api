using FragranceShopApi.Exceptions;
using FragranceShopApi.Services.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Services
{
    public interface IStaticFilesService : IScopedService
    {
        void DeleteFile(string path);
    }

    public class StaticFilesService : IStaticFilesService
    {
        public void DeleteFile(string path)
        {
            if (File.Exists(path)) File.Delete(path);
            else throw new FileNotFoundException();
        }        
    }
}

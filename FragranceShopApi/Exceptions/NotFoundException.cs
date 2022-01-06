using System;

namespace FragranceShopApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {    
        }
    }
}

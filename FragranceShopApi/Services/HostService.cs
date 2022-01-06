using FragranceShopApi.Services.Common;
using Microsoft.AspNetCore.Http;

namespace FragranceShopApi.Services
{
    public interface IHostService : IScopedService
    {
        string GetHostUrl();
    }

    public class HostService : IHostService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HostService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetHostUrl()
        {
            string scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            string host = _httpContextAccessor.HttpContext.Request.Host.Value;

            return $"{scheme}://{host}/";
        }
    }
}

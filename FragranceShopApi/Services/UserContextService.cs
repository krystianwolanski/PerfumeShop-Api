using FragranceShopApi.Extensions;
using FragranceShopApi.Services.Common;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FragranceShopApi.Services
{
    public interface IUserContextService : IScopedService
    {
        ClaimsPrincipal User { get; }
    }

    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;
    }
}

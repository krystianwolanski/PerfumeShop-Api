using FragranceShopApi.Models.Account;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FragranceShopApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            var token = _accountService.GenerateJwt(dto);

            return Ok(token);
        }
    }
}

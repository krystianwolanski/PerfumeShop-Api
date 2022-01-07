using FragranceShopApi.Models.User;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateUserDto dto, [FromRoute] int id)
        {
            _userService.Update(id, dto);

            return Ok();
        }
    }
}

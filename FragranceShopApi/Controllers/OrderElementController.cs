using FragranceShopApi.Models.OrderElement;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Controllers
{
    [Route("api/order/{orderId}/element")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrderElementController : ControllerBase
    {
        private readonly IOrderElementService _orderElementService;

        public OrderElementController(IOrderElementService orderElementService)
        {
            _orderElementService = orderElementService;
        }

        [HttpPut("{orderElementId}")]
        public ActionResult Update([FromRoute]int orderId, [FromRoute]int orderElementId, UpdateOrderElementDto dto)
        {
            _orderElementService.Update(orderId, orderElementId, dto);

            return Ok();
        }

        [HttpDelete("{orderElementId}")]
        public ActionResult Delete([FromRoute]int orderId, [FromRoute]int orderElementId)
        {
            _orderElementService.Delete(orderId, orderElementId);

            return NoContent();
        }
    }
}

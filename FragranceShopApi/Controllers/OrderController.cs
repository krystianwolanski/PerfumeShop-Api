using FragranceShopApi.Models;
using FragranceShopApi.Models.Order;
using FragranceShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Controllers
{
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([FromBody]CreateOrderDto dto)
        {
            var newOrderId = _orderService.Create(dto);

            return Created($"api/order/{newOrderId}", null);
        }

        [HttpPut("{orderId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Update([FromRoute]int orderId, [FromBody]UpdateOrderDto dto)
        {
            _orderService.Update(orderId, dto);

            return Ok();
        }

        [HttpDelete("{orderId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete([FromRoute]int orderId)
        {
            _orderService.Delete(orderId);

            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<PagedResult<OrderDto>> GetAll([FromQuery]OrderQueryFilter filter, [FromQuery]OrderQueryPager pager)
        {
            var orders = _orderService.GetAll(filter, pager);

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public ActionResult<OrderDto> Get([FromRoute]int orderId)
        {
            var order = _orderService.Get(orderId);

            return Ok(order);
        }

        [HttpPost("add")]
        public ActionResult Order([FromBody] MakeOrderDto dto)
        {
            var newOrderId = _orderService.MakeOrder(dto);
            
            return Created($"api/order/{newOrderId}", null);
        }
    }
}

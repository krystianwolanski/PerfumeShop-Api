using AutoMapper;
using Data;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Models.OrderElement;
using FragranceShopApi.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Services
{
    public interface IOrderElementService : IScopedService
    {
        void Update(int orderId, int orderElementId, UpdateOrderElementDto dto);
        void Delete(int orderId, int orderElementId);
    }
    public class OrderElementService : IOrderElementService
    {
        private readonly PerfumeDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderElementService(
            PerfumeDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Update(int orderId, int orderElementId, UpdateOrderElementDto dto)
        {
            var order = _dbContext.Orders
                .Where(o => o.Id == orderId)
                .Select(o => new
                {
                    OrderElement = o.OrderElements.FirstOrDefault(oe => oe.Id == orderElementId)
                })
                .FirstOrDefault();

            if (order is null)
                throw new NotFoundException("Order not found");

            if (order.OrderElement is null)
                throw new NotFoundException("Order element not found");

            _mapper.Map(dto, order.OrderElement);
            _dbContext.SaveChanges();
        }

        public void Delete(int orderId, int orderElementId)
        {
            var order = _dbContext.Orders
                .Where(o => o.Id == orderId)
                .Select(o => new
                {
                    OrderElement = o.OrderElements.FirstOrDefault(oe => oe.Id == orderElementId)
                })
                .FirstOrDefault();

            if (order is null)
                throw new NotFoundException("Order not found");

            if (order.OrderElement is null)
                throw new NotFoundException("Order element not found");

            _dbContext.Remove(order.OrderElement);
            _dbContext.SaveChanges();
        }
    }
}

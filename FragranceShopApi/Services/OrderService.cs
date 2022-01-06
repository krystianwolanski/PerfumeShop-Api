using AutoMapper;
using Data;
using Data.Entities;
using Data.Models;
using FragranceShopApi.Authorization.OrderAuthorization;
using FragranceShopApi.Exceptions;
using FragranceShopApi.Extensions;
using FragranceShopApi.Models;
using FragranceShopApi.Models.Order;
using FragranceShopApi.Services.Common;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Services
{
    public interface IOrderService : IScopedService
    {
        int Create(CreateOrderDto dto);
        void Update(int orderId, UpdateOrderDto dto);
        void Delete(int orderId);
        PagedResult<OrderDto> GetAll(OrderQueryFilter filter, OrderQueryPager pager);
        OrderDto Get(int orderId);
        int MakeOrder(MakeOrderDto dto);
    }

    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IUserContextService _userContextService;
        private readonly PerfumeDbContext _dbContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IHostService _hostService;

        public OrderService(
            IMapper mapper, 
            IUserContextService userContextService,
            PerfumeDbContext dbContext,
            IAuthorizationService authorizationService,
            IHostService hostService)
        {
            _mapper = mapper;
            _userContextService = userContextService;
            _dbContext = dbContext;
            _authorizationService = authorizationService;
            _hostService = hostService;
        }

        public int Create(CreateOrderDto dto)
        {
            var newOrder = _mapper.Map<Order>(dto);

            newOrder.OrderStatusId = OrderStatusId.Pending;

            _dbContext.Add(newOrder);
            _dbContext.SaveChanges();

            return newOrder.Id;
        }

        public void Update(int orderId, UpdateOrderDto dto)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);

            if (order is null)
                throw new NotFoundException("Order not found");

            _mapper.Map(dto, order);
            _dbContext.SaveChanges();
        }

        public void Delete(int orderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);

            if (order is null)
                throw new NotFoundException("Order not found");

            _dbContext.Remove(order);
            _dbContext.SaveChanges();
        }

        public PagedResult<OrderDto> GetAll(OrderQueryFilter filter, OrderQueryPager pager)
        {
            var baseQuery = _dbContext
                .Orders
                .AsQueryable();

            #region Filters
            if (filter.CompletedDateFrom.HasValue)
            {
                baseQuery = baseQuery.Where(o => o.CompletedDate >= filter.CompletedDateFrom);
            }

            if (filter.CompletedDateTo.HasValue)
            {
                baseQuery = baseQuery.Where(o => o.CompletedDate <= filter.CompletedDateTo);
            }

            if (filter.CreatedById.HasValue)
            {
                baseQuery = baseQuery.Where(o => o.CreatedById == filter.CreatedById);
            }

            if (filter.CustomerId.HasValue)
            {
                baseQuery = baseQuery.Where(o => o.CustomerId == filter.CustomerId);
            }    

            if (filter.DateCreatedFrom.HasValue)
            {
                baseQuery = baseQuery.Where(o => o.DateCreated >= filter.DateCreatedFrom);
            }    

            if (filter.DateCreatedTo.HasValue)
            {
                baseQuery = baseQuery.Where(o => o.DateCreated <= filter.DateCreatedTo);
            }
            #endregion

            var orders =
                SelectOrderDto(baseQuery.Paginate(pager))
                .ToList();

            var totalCount = baseQuery.Count();

            var result = new PagedResult<OrderDto>(orders, totalCount, pager.PageSize, pager.PageNumber);

            return result;
        }

        public OrderDto Get(int orderId)
        {
            var order = SelectOrderDto(_dbContext.Orders)
                .FirstOrDefault();

            if (order is null)
                throw new NotFoundException("Order not found");

            var orderAuthModel = new OrderAuthModel
            {
                CustomerId = order.Customer.Id
            };

            var user = _userContextService.User;
            var userCanGetOrder = _authorizationService.AuthorizeAsync(user, orderAuthModel,
                new OrderOperationRequirement(OrderOperation.Get)).Result;

            if (!userCanGetOrder.Succeeded)
                throw new ForbidException();

            return order;
        }

        public int MakeOrder(MakeOrderDto dto)
        {
            var newOrder = _mapper.Map<Order>(dto);
            var userId = _userContextService.User.GetUserId();
            
            newOrder.CustomerId = userId;
            newOrder.OrderStatusId = OrderStatusId.Pending;

            _dbContext.Add(newOrder);
            _dbContext.SaveChanges();

            return newOrder.Id;
        }

        private IQueryable<OrderDto> SelectOrderDto(IQueryable<Order> query)
        {
            var hostUrl = _hostService.GetHostUrl();

            return query
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderStatusId = o.OrderStatusId,
                    CompletedDate = o.CompletedDate,
                    DateCreated = o.DateCreated,
                    CreatedBy = new Models.Account.UserDto
                    {
                        Id = o.CreatedBy.Id,
                        FirstName = o.CreatedBy.FirstName,
                        LastName = o.CreatedBy.LastName
                    },
                    Customer = new Models.Account.UserDto
                    {
                        Id = o.Customer.Id,
                        FirstName = o.Customer.FirstName,
                        LastName = o.Customer.LastName
                    },
                    OrderElements = o.OrderElements.Select(oe => new Models.OrderElement.OrderElementDto
                    {
                        Id = oe.Id,
                        Perfume = new Models.Perfume.PerfumeInOrderDto
                        {
                            Id = oe.PerfumeId,
                            BasePrice = oe.Perfume.BasePrice,
                            CurrentPrice = oe.Perfume.CurrentPrice,
                            Capacity = oe.Perfume.Capacity,
                            Name = oe.Perfume.Name,
                            Year = oe.Perfume.Year,
                            PerfumeBrandName = oe.Perfume.PerfumeBrand.Name,
                            PerfumeGenderType = oe.Perfume.PerfumeGenderType.Name,
                            PerfumeImageUrl = oe.Perfume.PerfumeImgs
                                .Where(pi => pi.IsPrimary)
                                .Select(pi => hostUrl + pi.ThumbnailImageUrl)
                                .FirstOrDefault()

                        },
                        Quantity = oe.Quantity
                    }).ToList()
                });

        }
    }
}

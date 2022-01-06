using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Authorization.OrderAuthorization
{
    public enum OrderOperation
    {
        Get
    }

    public class OrderOperationRequirement : IAuthorizationRequirement
    {
        public OrderOperation Operation { get; }

        public OrderOperationRequirement(OrderOperation operation)
        {
            Operation = operation;
        }
    }
}

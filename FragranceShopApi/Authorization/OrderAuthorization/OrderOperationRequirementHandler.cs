using Data.Entities;
using FragranceShopApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Authorization.OrderAuthorization
{
    public class OrderOperationRequirementHandler : AuthorizationHandler<OrderOperationRequirement, OrderAuthModel>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OrderOperationRequirement requirement, OrderAuthModel resource)
        {
            if (requirement.Operation == OrderOperation.Get)
            {
                if (context.User.IsInRole("Admin"))
                    context.Succeed(requirement);

                else if (resource.CustomerId == context.User.GetUserId())
                    context.Succeed(requirement);

            }

            return Task.CompletedTask;
        }
    }
}

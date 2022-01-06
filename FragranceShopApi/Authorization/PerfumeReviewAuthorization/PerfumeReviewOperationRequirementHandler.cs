using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Authorization.PerfumeReviewAuthorization
{
    public class PerfumeReviewOperationRequirementHandler : AuthorizationHandler<PerfumeReviewOperationRequirement, PerfumeReviewAuthModel>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PerfumeReviewOperationRequirement requirement, PerfumeReviewAuthModel resource)
        {
            if (requirement.Operation == PerfumeReviewOperation.Add)
            {
                if (resource.UserHasGetSpecificPerfume == true)
                    context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FragranceShopApi.Authorization.PerfumeReviewAuthorization
{
    public enum PerfumeReviewOperation
    {
        Add
    }

    public class PerfumeReviewOperationRequirement : IAuthorizationRequirement
    {
        public PerfumeReviewOperation Operation { get; }

        public PerfumeReviewOperationRequirement(PerfumeReviewOperation operation)
        {
            Operation = operation;
        }
    }
}

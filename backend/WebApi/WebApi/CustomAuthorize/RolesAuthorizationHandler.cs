using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.CustomAuthorize
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>,IAuthorizationHandler
    {

        public RolesAuthorizationHandler()
        {

        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}

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
            //var roleItems = requirement.AllowedRoles.ToArray();
            //var validRole = false;
            //if (requirement.AllowedRoles == null ||
            //    requirement.AllowedRoles.Any() == false)
            //{
            //    validRole = true;
            //}
            //else
            //{
            //    var claims = context.User.Claims;
            //    var userId = claims.FirstOrDefault(c => c.Type == "UserId");
            //    if(userId != null)
            //    {
            //        var roles = requirement.AllowedRoles;

            //        var roleSelecteds = (from user in _userRepo.GetAll()
            //                    join role in _roleRepo.GetAll()
            //                    on user.RoleId equals role.RoleId
            //                    where user.UserId.ToString() == userId.Value
            //                    select new Role {
            //                        RoleId = role.RoleId,
            //                        RoleName = role.RoleName
            //                    }).FirstOrDefault();
            //        if (roleSelecteds != null && roleItems.Contains(roleSelecteds.RoleName))
            //        {
            //            validRole = true;
            //        }
            //    }
            //}

            //if (validRole)
            //{
            //    context.Succeed(requirement);
            //}
            //else
            //{
            //    context.Fail();
            //}
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}

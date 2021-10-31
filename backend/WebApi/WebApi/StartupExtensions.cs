using Core.Config;
using Core.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.CustomAuthorize;

namespace WebApi
{
    public static class StartupExtensions
    {
        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddCustomService(this IServiceCollection services, IConfiguration configuration)
        {
            //config dependency injection
            services.DependencyInjectionService(configuration);
            services.DependencyInjectionRepository(configuration);

            //config auto mapper
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            //config authen and author
            services.AddAuthentication("CookieAuthentication")
                 .AddCookie("CookieAuthentication", config =>
                 {
                     config.Cookie.Name = "UserLoginCookie"; // Name of cookie   
                     config.LoginPath = "/Login/UserLogin"; // Path for the redirect to user login page  
                 });

            services.AddAuthorization(config =>
            {
                var userAuthPolicyBuilder = new AuthorizationPolicyBuilder();
                config.DefaultPolicy = userAuthPolicyBuilder
                                    .RequireAuthenticatedUser()
                                    .RequireClaim(ClaimTypes.DateOfBirth)
                                    .Build();
            });
            services.AddScoped<IAuthorizationHandler, PoliciesAuthorizationHandler>();
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();
        }

    }
}

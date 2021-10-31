using AutoMapper;
using Core;
using Core.Base;
using Core.Service;
using EntityFramework.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        public UserController(IUserRepository userRepository):base(userRepository)
        {
        }

        [HttpPost("login")]
        public IActionResult Login(User dto)
        {
            try
            {
                if(dto.UserName == "admin" && dto.Password == "123qwe")
                {
                    return Ok(DataResult.ResultSuccess("Login Success"));
                }
                return Ok(DataResult.ResultError("","Login Fail"));
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.SignOutAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return Ok(e);
            }
        }
    }
}

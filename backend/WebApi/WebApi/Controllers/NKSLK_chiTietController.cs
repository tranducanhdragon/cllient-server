using Microsoft.AspNetCore.Mvc;
using Core.Service;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Base;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NKSLK_chiTietController : BaseController<Nkslk>
    {
        INKSLKRepository _NKSLKRepo;
        public NKSLK_chiTietController(INKSLKRepository nKSLK) : base(nKSLK)
        {
            _NKSLKRepo = nKSLK;
        }

    }
}

using Core.Service;
using EntityFramework.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    
    [Route("api/[controller]")]
    public class CongViecController : BaseController<CongViec>
    {
        ICongViecRepository congViecRepository;
        public CongViecController(ICongViecRepository congViec) : base(congViec)
        {
            congViecRepository = congViec;
        }
    }
}

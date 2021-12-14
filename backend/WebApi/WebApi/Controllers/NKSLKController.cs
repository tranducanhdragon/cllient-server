using Microsoft.AspNetCore.Mvc;
using Core.Service;
using EntityFramework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Controllers.Base;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NKSLKController : BaseController<Nkslk>
    {
        INKSLKRepository _NKSLKRepo;
        public NKSLKController(INKSLKRepository nKSLK) : base(nKSLK)
        {
            _NKSLKRepo = nKSLK;
        }
        [HttpGet("getallnkslkchitiets")]
        public IActionResult GetAllNKSLKChiTiets()
        {
            try
            {
                var result = _NKSLKRepo.GetAllNKSLKChiTiets();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost("insertnkslk")]
        public bool InsertNKSLK([FromBody] NKSLKChiTietCreate nkslkchitietcreate)
        {
            return _NKSLKRepo.CreateNKSLK(nkslkchitietcreate);
        }

    }
}

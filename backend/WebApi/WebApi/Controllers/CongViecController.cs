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
        [HttpPost("createcongviec")]
        public IActionResult CreateCongViec([FromBody] CongViecDto dto)
        {
            try
            {
                congViecRepository.CreateCongViec(dto);
                return Ok();
            }
            catch (Exception)
            {
                return Ok();
            }
        }

        [HttpDelete("deleteCongViecWithId/{maCongViec}")]
        public bool deleteCongViecWithId(int maCongViec)
        {

            return congViecRepository.DeleteCongViecWithId(maCongViec);
        }

        [HttpPut("updateCongViec")]
        public bool UpdateCongViec([FromBody] CongViecDtoUpdate congViecDtoUpdate)
        {
            return congViecRepository.UpdateCongViec(congViecDtoUpdate.MaCongViec, congViecDtoUpdate.TenCongViec, 
                congViecDtoUpdate.DinhMucKhoan, congViecDtoUpdate.DonViKhoan, congViecDtoUpdate.HeSoKhoan, congViecDtoUpdate.DinhMucLaoDong);
        }
    }
}

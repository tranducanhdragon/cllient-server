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
    public class SanPhamController : BaseController<SanPham>
    {
        ISanPhamRepository sanPhamRepository;
        public SanPhamController(ISanPhamRepository sanPham) : base(sanPham)
        {
            sanPhamRepository= sanPham;
        }

        [HttpGet("getSanPhamCoNgayDangKyTruocNgay")]
        public IActionResult getSpCoNgayDangKyTruocNgay([FromQuery] string date)
        {
            try
            {
                var result = sanPhamRepository.getSanPhamCoNgayDangKyTruocNgay(date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("getSanPhamCoHanSuDungTrenNam")]
        public IActionResult getSanPhamCoHanSuDungTrenNam([FromQuery] int soNam)
        {
            try
            {
                var result = sanPhamRepository.getSanPhamCoHanSuDungTrenNam(soNam);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost("createsanpham")]
        public bool CreateSanPham([FromBody] SanPhamDto dto)
        {
            return sanPhamRepository.createSanPham(dto);
        }
    }
}

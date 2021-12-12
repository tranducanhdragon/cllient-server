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
    public class ThongKeController: ControllerBase
    {
        IThongKeRepository _thongkeRepo;
        public ThongKeController(IThongKeRepository thongkeRepos)
        {
            _thongkeRepo = thongkeRepos;
        }
        [HttpGet("getcongviecmaxslk")]
        public IActionResult GetCongViecMaxSLK()
        {
            try
            {
                var result = _thongkeRepo.GetCongViecMaxSLK();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("getcongviecdongiamax")]
        public IActionResult GetCongViecDonGiaMax()
        {
            try
            {
                var result = _thongkeRepo.GetCongViecDonGiaMax();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("getcongviecdongiamin")]
        public IActionResult GetCongViecDonGiaMin()
        {
            try
            {
                var result = _thongkeRepo.GetCongViecDonGiaMin();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("getcongvieclonhondontb")]
        public IActionResult GetCongViecLonHonDonTB()
        {
            try
            {
                var result = _thongkeRepo.GetCongViecLonHonDonTB();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("getcongviecnhohondontb")]
        public IActionResult GetCongViecNhoHonDonTB()
        {
            try
            {
                var result = _thongkeRepo.GetCongViecNhoHonDonTB();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("getallnhancongthang")]
        public IActionResult GetAllNhanCongThang([FromQuery] int thang)
        {
            try
            {
                var result = _thongkeRepo.GetNhanCongsThang(thang);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("getnkslknhancongthang")]
        public IActionResult GetNKSLKNhanCongThang([FromQuery]int manhancong, [FromQuery]int thang)
        {
            try
            {
                var result = _thongkeRepo.GetNKSLKNhanCongThang(manhancong, thang);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("getallcongviec")]
        public IActionResult GetAllCongViec()
        {
            try
            {
                var result = _thongkeRepo.GetAllCongViec();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("getluongnhancongbythangcongviec")]
        public IActionResult GetAllCongViec([FromQuery] int thang, [FromQuery] int macongviec)
        {
            try
            {
                var result = _thongkeRepo.GetLuongNhanCongByThangCongViec(thang, macongviec);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}

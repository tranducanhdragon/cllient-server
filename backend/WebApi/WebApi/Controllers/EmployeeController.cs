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
    public class EmployeeController : BaseController<NhanCong>
    {
        INhanCongRepository _nhancongRepo;
        public EmployeeController(INhanCongRepository employeeRepository) : base(employeeRepository)
        {
            _nhancongRepo = employeeRepository;
        }
        

        [HttpPost("updateEmployee")]
        public IActionResult update([FromBody] NhanCongDto entity)
        {
            try
            {
                _nhancongRepo.EditNhanCong(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost("insertNhanCong")]
        public IActionResult insert([FromBody] NhanCongDto entity)
        {
            try
            {
                var result = _nhancongRepo.CreateCongNhan(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        /*
        [HttpGet("nhanCongSapNghiHuu")]
        public IActionResult nhanCongSapNghiHuu()
        {
            try
            {
                var result = _nhancongRepo.nhanCongSapNghiHuu();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        */
        [HttpGet("nhanCongSapNghiHuu")]
        public IActionResult nhanCongSapNghiHuu()
        {
            try
            {
                var result = _nhancongRepo.nhanCongSapNghiHuu();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("nhanCong30_45")]
        public IActionResult nhanCong30_45()
        {
            try
            {
                var result = _nhancongRepo.nhanCong30_45();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("nhanCongCa3")]
        public IActionResult nhanCongCa3()
        {
            try
            {
                var result = _nhancongRepo.nhanCong30_45();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpDelete("deletebyid")]
        public IActionResult Delete(int manhancong)
        {
            try
            {
                bool canDelete = _nhancongRepo.DeleteNhanCong(manhancong);
                if (canDelete == true) { 
                    return Ok();
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }



    }
}

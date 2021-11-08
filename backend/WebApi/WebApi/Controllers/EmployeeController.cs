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
        [HttpDelete("deletebyid")]
        public IActionResult Delete(int manhancong)
        {
            try
            {
                _nhancongRepo.DeleteNhanCong(manhancong);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}

using Core;
using Core.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.Base
{
    public class BaseController<TEntity> : ControllerBase
        where TEntity : class
    {
        public IBaseRepository<TEntity> _service;
        public BaseController(IBaseRepository<TEntity> service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPost("insert")]
        public IActionResult Insert([FromBody] TEntity entity)
        {
            try
            {
                var result = _service.Create(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _service.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] TEntity item)
        {
            try
            {
                _service.Update(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] TEntity entity)
        {
            try
            {
                _service.Delete(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}

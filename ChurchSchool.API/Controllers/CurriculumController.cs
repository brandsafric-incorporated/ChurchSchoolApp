using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Curriculum")]
    public class CurriculumController : Controller
    {
        private ICurriculum _curriculumApp;

        public CurriculumController(ICurriculum curriculumApp)
        {
            _curriculumApp = curriculumApp;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = _curriculumApp.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid key, [FromBody] Domain.Entities.Curriculum curriculum)
        {
            try
            {
                var relatedItem = _curriculumApp.GetById(key);

                if (relatedItem == null)
                    return NotFound(key);

                if (!curriculum.Id.HasValue)
                    curriculum.Id = key;

                var result = _curriculumApp.Update(curriculum);

                if (!result.Errors.Any())
                    return Ok();
                else
                    return BadRequest(curriculum.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Domain.Entities.Curriculum curriculum)
        {
            try
            {
                var result = _curriculumApp.Add(curriculum);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpDelete]
        public IActionResult Delete(Guid key)
        {
            try
            {
                var relatedItem = _curriculumApp.GetById(key);

                if (relatedItem == null)
                    return NotFound();

                var result = _curriculumApp.Remove(key);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
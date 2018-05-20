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
    [Route("api/[controller]")]
    public class CouseConfigurationController : Controller
    {
        private readonly ICourseConfiguration _courseConfiguration;

        public CouseConfigurationController(ICourseConfiguration courseConfiguration)
        {
            _courseConfiguration = courseConfiguration;
        }


        [HttpGet]
        [Route("Course/Configurations")]
        public IActionResult Get()
        {
            try
            {
                var result = _courseConfiguration.GetAll();

                if (result.Any())
                    return Ok(result);
                else
                    return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet]
        [Route("Course/Configurations/{couse}")]
        public IActionResult GetByCourse(Guid course)
        {
            try
            {
                var result = _courseConfiguration.GetByCourse(course);

                if (result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("Course/Configurations/")]
        public IActionResult Put(Guid key, [FromBody]Domain.Entities.CourseConfiguration configuration)
        {
            try
            {
                var relatedItem = _courseConfiguration.GetById(key);

                if (relatedItem == null)
                    return NotFound(key);

                if (!relatedItem.Id.HasValue)
                    relatedItem.Id = key;

                var result = _courseConfiguration.Update(configuration);

                if (result)
                    return Ok(result);
                else
                    return BadRequest(configuration);
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
                var result = _courseConfiguration.Remove(key);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
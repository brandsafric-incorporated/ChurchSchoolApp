using System;
using System.Linq;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Course/Settings")]
    [Authorize]
    public class CouseConfigurationController : Controller
    {
        private readonly ICourseConfiguration _courseConfiguration;
        private readonly IUnitOfWork _unitOfWork;

        public CouseConfigurationController(ICourseConfiguration courseConfiguration, IUnitOfWork unitOfWork)
        {
            _courseConfiguration = courseConfiguration;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
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
        [Route("{couse}")]
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

        [HttpPost]
        public IActionResult Post([FromBody]Domain.Entities.CourseConfiguration configuration)
        {
            try
            {
                if (configuration == null)
                {
                    return BadRequest();
                }

                var createdConfiguration = _courseConfiguration.Add(configuration);

                _unitOfWork.Commit();

                if (createdConfiguration.Errors.Any())
                {
                    return BadRequest(createdConfiguration.Errors);
                }
                else
                {
                    return Ok(createdConfiguration);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid key, [FromBody]Domain.Entities.CourseConfiguration configuration)
        {
            try
            {
                var relatedItem = _courseConfiguration.GetById(key);

                if (relatedItem == null)
                    return NotFound(key);

                if (!configuration.Id.HasValue)
                    configuration.Id = key;

                var result = _courseConfiguration.Update(configuration);

                _unitOfWork.Commit();

                if (!result.Errors.Any())
                    return Ok();
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

                _unitOfWork.Commit();

                if (!result.Errors.Any())
                    return Ok();
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
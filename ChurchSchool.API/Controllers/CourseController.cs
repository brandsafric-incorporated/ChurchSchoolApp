using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;

namespace ChurchSchool.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/course")]
    public class CourseController : Controller
    {
        private readonly ICourse _course;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptions<ApplicationSettings> _extendedOptions;

        public CourseController(ICourse course,
                                IUnitOfWork unitOfWork,
                                IOptions<ApplicationSettings> extendedOptions)
        {
            _course = course;
            _unitOfWork = unitOfWork;
            _extendedOptions = extendedOptions;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _course.GetAll();

                return Ok(result.ToArray());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("FilterByName")]
        public IActionResult Get([FromQuery]string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest();

                var result = _course.Filter(name);

                if (result == null || !result.Any())
                {
                    return NotFound();
                }                    

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        
        [HttpGet, Route("FilterById")]
        public IActionResult Get([FromQuery]long id)
        {
            try
            {
                var result = _course.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }                    

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("Filter")]
        public IActionResult Get(long? id, string name, bool? isActive)
        {
            try
            {
                var result = _course.Filter(new Course
                {
                    Id = id,
                    Name = name,
                    IsActive = isActive
                });


                if(result == null || !result.Any())
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Course course)
        {
            try
            {
                var result = _course.Add(course);
                
                if (result.Errors.Any())
                {
                    return BadRequest(result.Errors);
                }                    

                _unitOfWork.Commit();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Put(long key, [FromBody] Course course)
        {
            try
            {
                var relatedItem = _course.GetById(key);

                if (relatedItem == null)
                    return NotFound(key);

                if (!course.Id.HasValue)
                    course.Id = key;

                var result = _course.Update(course);

                _unitOfWork.Commit();

                if (result)
                    return Ok();
                else
                    return BadRequest(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(long key)
        {
            try
            {
                var relatedItem = _course.GetById(key);

                if (relatedItem == null)
                    return NotFound();

                var result = _course.Remove(key);

                _unitOfWork.Commit();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }      
    }
}
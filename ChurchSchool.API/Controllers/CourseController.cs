using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using ChurchSchool.Shared;
using Microsoft.Extensions.Options;

namespace ChurchSchool.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Course")]    
    public class CourseController : Controller
    {
        private readonly ICourse _course;
        private readonly IUnitOfWorkIdentity _unitOfWork;
        private readonly IOptions<ApplicationSettings> _extendedOptions;

        public CourseController(ICourse course,
                                IUnitOfWorkIdentity unitOfWork,
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

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest();

                var result = _course.Filter(name);

                if (result == null)
                    return NotFound();

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
                
                _unitOfWork.Commit();

                if (result.Errors.Any())
                    return BadRequest(result.Errors);

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

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application = ChurchSchool.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Repository;
using Microsoft.AspNetCore.Authorization;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Course")]
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourse _course;
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(ICourse course, IUnitOfWork unitOfWork)
        {
            _course = course;
            _unitOfWork = unitOfWork;
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
        public IActionResult Put(Guid key, [FromBody] Course course)
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
        public IActionResult Delete(Guid key)
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
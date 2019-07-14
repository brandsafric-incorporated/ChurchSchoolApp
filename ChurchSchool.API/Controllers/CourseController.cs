using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchSchool.API.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/Course")]
    public class CourseController : Controller
    {
        private readonly ICourse _course;

        private readonly IOptions<ApplicationSettings> _extendedOptions;

        public CourseController(ICourse course,
                                IOptions<ApplicationSettings> extendedOptions)
        {
            _course = course;            
            _extendedOptions = extendedOptions;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return await Task.Run(() =>
                {
                    var result = _course.GetAll();

                    return Ok(result.ToArray());
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                return await Task.Run(() =>
                {
                    IActionResult response = null;

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        response = BadRequest();
                    }
                    else
                    {
                        var result = _course.Filter(name);

                        if (result == null)
                        {
                            response = NotFound();
                        }
                        else
                        {
                            response = Ok(result);
                        }
                    }

                    return response;
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Course course)
        {
            try
            {
                return await Task.Run(() =>
                {
                    IActionResult response = null;

                    var result = _course.Add(course);

                    if (result.Errors.Any())
                    {
                        response = BadRequest(result.Errors);
                    }
                    else
                    {
                        response = Ok(result);
                    }

                    return response;
                });
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
                {
                    return NotFound(key);
                }

                if (!course.Id.HasValue)
                {
                    course.Id = key;
                }

                var result = _course.Update(course);

                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(course);
                }
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
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
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private IStudent _student;

        public StudentController(IStudent student)
        {
            _student = student;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _student.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Domain.Entities.Student entity)
        {
            try
            {
                var result = _student.Add(entity);

                if (!result.Errors.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Errors);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid key, [FromBody] Domain.Entities.Student entity)
        {
            try
            {
                var updateResult = _student.Update(entity);

                if (updateResult.Errors.Any())
                {
                    return BadRequest(updateResult.Errors);
                }

                return Ok(updateResult);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IStudent student, IUnitOfWork unitOfWork)
        {
            _student = student;
            _unitOfWork = unitOfWork;
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

                _unitOfWork.Commit();

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
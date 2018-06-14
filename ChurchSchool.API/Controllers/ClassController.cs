using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Class")]
    public class ClassController : Controller
    {
        private ICourseClass _courseClass;
        private IUnitOfWork _unitOfWork;

        public ClassController(ICourseClass courseClass, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _courseClass = courseClass;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _courseClass.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Domain.Entities.CourseClass entity)
        {
            try
            {
                var result = _courseClass.Add(entity);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                {
                    return BadRequest(result.Errors);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Domain.Entities.CourseClass entity)
        {
            try
            {
                var result = _courseClass.Update(entity);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                    return BadRequest(result.Errors);
                else
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
                var result = _courseClass.Remove(key);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                    return BadRequest(result.Errors);
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Curriculum")]
    [Authorize]
    public class CurriculumController : Controller
    {
        private readonly ICurriculum _curriculumApp;

        private readonly IUnitOfWork _unitOfWork;

        public CurriculumController(ICurriculum curriculumApp, IUnitOfWork unitOfWork)
        {
            _curriculumApp = curriculumApp;
            _unitOfWork = unitOfWork;
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

                _unitOfWork.Commit();

                if (!result.Errors.Any())
                    return Ok();
                else
                    return BadRequest(result.Errors);
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

                _unitOfWork.Commit();

                if (result.Errors.Any())
                {
                    return BadRequest(result.Errors);
                }
                else
                {
                    return Ok(result);
                }
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
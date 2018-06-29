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
    [Route("api/Professor")]
    [Authorize]
    public class ProfessorController : Controller
    {
        private IProfessor _professor;
        private IUnitOfWork _unitOfWork;

        public ProfessorController(IProfessor professor, IUnitOfWork unitOfWork)
        {
            _professor = professor;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _professor.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet, Route("{key}")]
        public IActionResult Filter(Guid key)
        {
            try
            {
                var result = _professor.GetById(key);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Domain.Entities.Professor entity)
        {
            try
            {
                var result = _professor.Add(entity);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                    return BadRequest(result.Errors);

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid id, [FromBody] Domain.Entities.Professor entity)
        {
            try
            {
                var result = _professor.Update(entity);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                    return BadRequest(result.Errors);

                return NoContent();
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
                var result = _professor.Remove(key);

                _unitOfWork.Commit();

                if (result.Errors.Any())
                    return BadRequest(result.Errors);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
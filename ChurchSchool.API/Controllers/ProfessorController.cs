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
    [Route("api/Professor")]
    public class ProfessorController : Controller
    {
        private IProfessor _professor;


        public ProfessorController(IProfessor professor)
        {
            _professor = professor;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Domain.Entities.Professor entity)
        {
            try
            {
                var result = _professor.Add(entity);

                if (result.Errors.Any())
                    return BadRequest(result.Errors);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
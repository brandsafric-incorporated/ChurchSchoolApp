using System;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Professors")]
    public class ProfessorsController : Controller
    {
        private IProfessorRepository _ProfessorRepository;

        public ProfessorsController(IProfessorRepository ProfessorRepository)
        {
            _ProfessorRepository = ProfessorRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _ProfessorRepository.GetAll().ToList();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                var results = _ProfessorRepository.Filter(new Professor { Name = name }).FirstOrDefault();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor Professor)
        {
            try
            {
                var result = await _ProfessorRepository.Add(Professor);

                if (result.Id.HasValue)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Professor Professor)
        {
            try
            {
                var entity = _ProfessorRepository.Filter(new Professor { Id = id }).FirstOrDefault();

                if (entity == null)
                {
                    //put a log call here
                    return BadRequest("Professor not found");
                }

                var result = await _ProfessorRepository.Update(entity);

                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


    }
}
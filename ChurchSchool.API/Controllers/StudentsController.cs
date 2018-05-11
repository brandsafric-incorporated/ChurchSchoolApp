using System;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        private IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(Student))]
        public IActionResult Get()
        {
            try
            {
                var result = _studentRepository.GetAll().ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{name}")]
        [Produces("application/json", Type = typeof(Student))]
        public IActionResult Get(string name)
        {
            try
            {
                var results = _studentRepository.Filter(new Student { Name = name }).FirstOrDefault();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Produces("application/json", Type = typeof(Student))]
        public async Task<IActionResult> Post([FromBody]Student student)
        {
            try
            {
                var result = await _studentRepository.Add(student);

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
        [Produces("application/json")]
        public async Task<IActionResult> Put(Guid id, Student student)
        {
            try
            {
                var entity = _studentRepository.Filter(new Student { Id = id }).FirstOrDefault();

                if (entity == null)
                {
                    //put a log call here
                    return BadRequest("Student not found");
                }

                var result = await _studentRepository.Update(entity);

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
using System;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
        private ICourseRepository _CourseRepository;

        public CoursesController(ICourseRepository CourseRepository)
        {
            _CourseRepository = CourseRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _CourseRepository.GetAll().ToList();
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
                var results = _CourseRepository.Filter(new Course { Name = name }).FirstOrDefault();

                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Course Course)
        {
            try
            {
                var result = await _CourseRepository.Add(Course);

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
        public async Task<IActionResult> Put(Guid id, Course Course)
        {
            try
            {
                var entity = _CourseRepository.Filter(new Course { Id = id }).FirstOrDefault();

                if (entity == null)
                {
                    //put a log call here
                    return BadRequest("Course not found");
                }

                var result = await _CourseRepository.Update(entity);

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
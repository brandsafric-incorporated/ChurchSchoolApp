using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Subject")]
    public class SubjectController : Controller
    {
        private readonly ISubject _subject;

        public SubjectController(ISubject Subject)
        {
            _subject = Subject;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _subject.GetAll();

                return Ok(result.ToArray());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    return BadRequest();

                var result = _subject.Filter(name);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Subject Subject)
        {
            try
            {
                var result = _subject.Add(Subject);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public IActionResult Put(Guid key, [FromBody] Subject subject)
        {
            try
            {
                var relatedItem = _subject.GetById(key);

                if (relatedItem == null)
                    return NotFound(key);

                if (!subject.Id.HasValue)
                    subject.Id = key;

                var result = _subject.Update(subject);

                if (!result.Errors.Any())
                    return Ok();
                else
                    return BadRequest(subject);
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
                var relatedItem = _subject.GetById(key);

                if (relatedItem == null)
                    return NotFound();

                var result = _subject.Remove(key);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
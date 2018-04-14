using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.Domain.Entities;
using ChurchSchool.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private StudentRepository _studentRepository;

        public StudentsController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentRepository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(Guid id)
        {
            return _studentRepository.Filter(new Student { Id = id })
                                     .FirstOrDefault();
        }

        // POST api/values
        [HttpPost]
        public Student Post([FromBody]Student model)
        {
            return _studentRepository.Add(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public bool Put(Guid id, [FromBody]Student model)
        {
            return _studentRepository.Update(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _studentRepository.Remove(id);
        }
    }
}

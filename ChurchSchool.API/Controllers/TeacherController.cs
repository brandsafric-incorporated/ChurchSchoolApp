using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSchool.API.Models;
using ChurchSchool.Application.Contracts;
using ChurchSchool.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChurchSchool.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Teacher")]
    public class TeacherController : Controller
    {
        private IProfessor _professor;
        private IUnitOfWork _unitOfWork;

        public TeacherController(IProfessor professor, IUnitOfWork unitOfWork)
        {
            _professor = professor;
            _unitOfWork = unitOfWork;
        }



        [HttpPost]
        public IActionResult Post([FromBody] Domain.Entities.Student model)
        {
            try
            {
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}